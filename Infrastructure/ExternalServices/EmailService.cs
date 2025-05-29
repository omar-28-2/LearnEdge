using Microsoft.Extensions.Configuration;
using SendGrid;
using SendGrid.Helpers.Mail;

namespace Infrastructure.ExternalServices
{
    public interface IEmailService
    {
        Task SendEmailAsync(string to, string subject, string htmlContent);
    }

    public class EmailService : IEmailService
    {
        private readonly IConfiguration _configuration;
        private readonly ISendGridClient _sendGridClient;

        public EmailService(IConfiguration configuration)
        {
            _configuration = configuration;
            var apiKey = _configuration["SendGrid:ApiKey"] ?? throw new InvalidOperationException("SendGrid API Key not configured");
            _sendGridClient = new SendGridClient(apiKey);
        }

        public async Task SendEmailAsync(string to, string subject, string htmlContent)
        {
            var from = new EmailAddress(_configuration["SendGrid:FromEmail"] ?? throw new InvalidOperationException("SendGrid From Email not configured"), 
                                      _configuration["SendGrid:FromName"] ?? "LearnEdge");
            var toAddress = new EmailAddress(to);
            var msg = MailHelper.CreateSingleEmail(from, toAddress, subject, null, htmlContent);
            
            var response = await _sendGridClient.SendEmailAsync(msg);
            
            if (response.StatusCode != System.Net.HttpStatusCode.Accepted)
            {
                throw new Exception($"Failed to send email. Status code: {response.StatusCode}");
            }
        }
    }
} 
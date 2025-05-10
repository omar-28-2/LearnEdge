using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System.IO;

namespace Infrastructure.Contexts
{
    public class StudentVoiceDbContextFactory : IDesignTimeDbContextFactory<LearnEdgeDbContext>
    {
        public LearnEdgeDbContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<LearnEdgeDbContext>();

            // Load configuration from appsettings.json
            var configuration = new ConfigurationBuilder()
                .SetBasePath(Path.Combine(Directory.GetCurrentDirectory(), "..", "API")) 
                .AddJsonFile("appsettings.json")
                .Build();

            string connectionString = configuration.GetConnectionString("DefaultConnection") ?? throw new InvalidOperationException("Connection string 'DefaultConnection' is not found.");

            optionsBuilder.UseSqlServer(connectionString);

            return new LearnEdgeDbContext(optionsBuilder.Options);
        }
    }
}
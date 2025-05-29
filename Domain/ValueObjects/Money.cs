using System.ComponentModel.DataAnnotations;

namespace Domain.ValueObjects
{
    public class Money
    {
        [Required]
        [Range(0, double.MaxValue)]
        public decimal Amount { get; set; }

        [Required]
        [StringLength(3)]
        public string Currency { get; set; } = "USD";

        public Money(decimal amount, string currency = "USD")
        {
            Amount = amount;
            Currency = currency;
        }

        public static Money operator +(Money a, Money b)
        {
            if (a.Currency != b.Currency)
                throw new InvalidOperationException("Cannot add money with different currencies");
            
            return new Money(a.Amount + b.Amount, a.Currency);
        }

        public static Money operator -(Money a, Money b)
        {
            if (a.Currency != b.Currency)
                throw new InvalidOperationException("Cannot subtract money with different currencies");
            
            return new Money(a.Amount - b.Amount, a.Currency);
        }
    }
} 
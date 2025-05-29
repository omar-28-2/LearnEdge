using System.ComponentModel.DataAnnotations;

namespace Domain.ValueObjects
{
    public class Address
    {
        [Required]
        [StringLength(200)]
        public string Street { get; set; } = null!;

        [Required]
        [StringLength(100)]
        public string City { get; set; } = null!;

        [Required]
        [StringLength(100)]
        public string State { get; set; } = null!;

        [Required]
        [StringLength(100)]
        public string Country { get; set; } = null!;

        [Required]
        [StringLength(20)]
        public string PostalCode { get; set; } = null!;

        public Address(string street, string city, string state, string country, string postalCode)
        {
            Street = street;
            City = city;
            State = state;
            Country = country;
            PostalCode = postalCode;
        }

        public override string ToString()
        {
            return $"{Street}, {City}, {State} {PostalCode}, {Country}";
        }
    }
} 
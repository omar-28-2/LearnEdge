namespace Domain.DTOs
{
    public class StudentDTO
    {
     
        public string FullName { get; set; } = null!;
        public string Level { get; set; } = null!;
        public string Specialization { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string PhoneNumber { get; set; } = null!;

        public int Age { get; set; }

        public decimal TotalPaid { get; set; }

        public bool IsQRCodeValidated { get; set; }

        public bool IsActiveInCourse { get; set; }
    }
}

namespace Domain.DTOs
{
    public class UserDTO
    {
        public string FullName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string Role { get; set; }

        public string City { get; set; }
        public string Governorate { get; set; }

        public int Age { get; set; }
    }
}

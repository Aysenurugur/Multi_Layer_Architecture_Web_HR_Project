using System;

namespace WebAPI.DTOs
{
    public class UpdateUserDTO
    {
        public Guid Id { get; set; }
        public Guid CompanyID { get; set; } //FK
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public byte[] Photo { get; set; } //has column type ("image")
        public string Address { get; set; }
        public string Title { get; set; } // Unvan
        public string Department { get; set; }
        public string PhoneNumber { get; set; }
        public DateTime HiredDate { get; set; }
        public DateTime BirthDate { get; set; }
        public string Email { get; set; }
        public string PasswordHash { get; set; }
    }
}

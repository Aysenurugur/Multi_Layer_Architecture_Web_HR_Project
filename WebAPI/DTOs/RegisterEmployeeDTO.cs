using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.DTOs
{
    public class RegisterEmployeeDTO
    {
        public Guid Id { get; set; }
        public Guid CompanyID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public DateTime BirthDate { get; set; }
        public bool IsWoman { get; set; }
        public DateTime HiredDate { get; set; }
        public byte[] Photo { get; set; }
        public string Title { get; set; }
    }
}

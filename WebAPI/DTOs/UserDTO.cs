using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.DTOs
{
    public class UserDTO
    {
        public Guid Id { get; set; }
        public Guid CompanyID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}

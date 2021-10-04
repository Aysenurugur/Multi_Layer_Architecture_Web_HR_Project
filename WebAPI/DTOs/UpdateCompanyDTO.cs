using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.DTOs
{
    public class UpdateCompanyDTO
    {
        public Guid CompanyID { get; set; }
        public string CompanyName { get; set; }
        public string Address { get; set; }
        public DateTime? ExpirationDate { get; set; }
        public byte[] Logo { get; set; }
    }
}

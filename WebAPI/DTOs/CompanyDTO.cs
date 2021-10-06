using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.DTOs
{
    public class CompanyDTO
    {
        // site anasayası için 
        public Guid CompanyID { get; set; }
        public string CompanyName { get; set; }
        public byte[] Logo { get; set; }
        public string Address { get; set; }
    }
}

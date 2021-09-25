using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.DTOs
{
    public class CompanyDTO
    {
        // site anasayası için 
        public Guid Id { get; set; }
        public string CompanyName { get; set; }
        public byte[] Logo { get; set; }
    }
}

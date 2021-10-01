using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.DTOs
{
    public class BreakDTO
    {
        public Guid BreakID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}

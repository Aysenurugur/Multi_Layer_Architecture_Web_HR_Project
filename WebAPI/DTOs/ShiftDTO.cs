using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.DTOs
{
    public class ShiftDTO
    {
        //Manager vardiya sayfası
        public Guid Id { get; set; }
        public string FullName { get; set; }
        public DateTime? BeginDate { get; set; }
        
    }
}

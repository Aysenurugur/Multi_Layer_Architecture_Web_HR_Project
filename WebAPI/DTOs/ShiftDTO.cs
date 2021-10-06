using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.DTOs
{
    public class ShiftDTO
    {
        //Manager vardiya sayfası
        public Guid ShiftID { get; set; }
        public Guid UserID { get; set; }
        public DateTime? BeginDate { get; set; }
        public DateTime? EndDate { get; set; }
        
    }
}

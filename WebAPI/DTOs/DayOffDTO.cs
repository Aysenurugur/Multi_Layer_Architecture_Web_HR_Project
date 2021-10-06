using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.DTOs
{
    public class DayOffDTO
    {
        public Guid DayOffID { get; set; }
        public Guid UserID { get; set; }
        public Guid DayOffTypeID { get; set; }
        public DateTime? BeginDate { get; set; }
        public DateTime? EndDate { get; set; }
        public bool? IsApproved { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.DTOs
{
    public class EmployeeDayOffDTO
    {
        // Manager izinler sayfası 
        public int Id { get; set; }
        public string FullName { get; set; }
        public string DayOffType { get; set; }
        public int Duration { get; set; }
        public DateTime BeginDate { get; set; }
        public DateTime EndDate{ get; set; }
    }
}

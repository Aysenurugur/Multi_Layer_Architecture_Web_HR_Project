using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.DTOs
{
    public class VetoMessageDTO
    {
        public Guid VetoMessageID { get; set; }
        public Guid? DayOffID { get; set; }
        public Guid? DebitID { get; set; }
        public Guid? ExpenseID { get; set; }
        public Guid VetodBy { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}

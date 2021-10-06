using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.DTOs
{
    public class DayOffTypeDTO
    {
        public Guid DayOffTypeID { get; set; }
        public short Duration { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }

        public DateTime CreatedDate { get; set; }
     
    }
}

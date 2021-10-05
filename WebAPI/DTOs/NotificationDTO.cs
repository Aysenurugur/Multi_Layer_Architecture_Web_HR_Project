using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.DTOs
{
    public class NotificationDTO
    {        
        public Guid NotificationID { get; set; }
        public Guid UserID { get; set; }
        public string Description { get; set; }
        public DateTime? CreatedDate { get; set; }
    }
}

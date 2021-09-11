using Data.Entities.Base_Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Entities
{
    public class Notification : Title_Content
    {
        public int NotificationID { get; set; }
        public Guid UserID { get; set; }
        public DateTime CreatedDate { get; set; }
        public bool IsSeen { get; set; }

        //user nav prop gelecek
    }
}

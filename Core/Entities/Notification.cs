using Core.Entities.Base_Entities;
using Core.Entities.Identity;
using System;

namespace Core.Entities
{
    public class Notification : Title_Content
    {
        public Guid NotificationID { get; set; }
        public Guid UserID { get; set; }
        public bool IsSeen { get; set; }

        public User User { get; set; }
    }
}

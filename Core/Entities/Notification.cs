using Core.Entities.Base_Entities;
using Core.Entities.Identity;

namespace Core.Entities
{
    public class Notification : Title_Content
    {
        public int NotificationID { get; set; }
        public string UserID { get; set; }
        public bool IsSeen { get; set; }

        public User User { get; set; }
    }
}

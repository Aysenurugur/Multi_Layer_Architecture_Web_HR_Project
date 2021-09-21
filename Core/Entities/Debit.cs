using Core.Entities.Base_Entities;
using Core.Entities.Identity;

namespace Core.Entities
{
    public class Debit : Title_Content
    {
        public int DebitID { get; set; }
        public string UserID { get; set; }
        public int? VetoMessageID { get; set; }
        public bool IsApproved { get; set; }

        public VetoMessage VetoMessage { get; set; } //nav prop
        public User User { get; set; }
    }
}

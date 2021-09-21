using Core.Entities.Base_Entities;
using Core.Entities.Identity;

namespace Core.Entities
{
    public class VetoMessage : Title_Content
    {
        public int VetoMessageID { get; set; }
        public int? DayOffID { get; set; }
        public int? DebitID { get; set; }
        public int? ExpenseID { get; set; }
        public string VetodBy { get; set; } //userID yerine foreign key (az şekil yapalım)

        public DayOff DayOff { get; set; } //nav prop
        public Debit Debit { get; set; }
        public Expense Expense { get; set; }
        public User VetodByUser { get; set; }
    }
}

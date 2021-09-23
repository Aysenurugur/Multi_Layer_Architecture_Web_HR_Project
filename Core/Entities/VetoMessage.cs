using Core.Entities.Base_Entities;
using Core.Entities.Identity;
using System;

namespace Core.Entities
{
    public class VetoMessage : Title_Content
    {
        public Guid VetoMessageID { get; set; }
        public Guid? DayOffID { get; set; }
        public Guid? DebitID { get; set; }
        public Guid? ExpenseID { get; set; }
        public Guid VetodBy { get; set; } //userID yerine foreign key (az şekil yapalım)

        public DayOff DayOff { get; set; } //nav prop
        public Debit Debit { get; set; }
        public Expense Expense { get; set; }
        public User VetodByUser { get; set; }
    }
}

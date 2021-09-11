using Data.Entities.Base_Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Entities
{
    public class VetoMessage : Title_Content
    {
        public int VetoMessageID { get; set; }
        public int? DayOffID { get; set; }
        public int? DebitID { get; set; }
        public int? ExpenseID { get; set; }
        public Guid VetodBy { get; set; } //userID yerine foreign key (az şekil yapalım)
        public DateTime VetoDate { get; set; }

        public DayOff DayOff { get; set; } //nav prop
        public Debit Debit { get; set; }
        public Expense Expense { get; set; }
    }
}

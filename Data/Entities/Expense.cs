using Data.Entities.Base_Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Entities
{
    public class Expense : Title_Content
    {
        public int ExpenseID { get; set; }
        public Guid UserID { get; set; }
        public int? FileID { get; set; }
        public int? VetoMessageID { get; set; }
        public byte[] Image { get; set; }
        public decimal TotalPrice { get; set; }
        public bool IsApproved { get; set; }

        public File File { get; set; } //nav prop
        public VetoMessage VetoMessage { get; set; }
        //user nav prop gelecek
    }
}

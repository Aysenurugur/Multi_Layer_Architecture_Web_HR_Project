using Core.Entities.Base_Entities;
using Core.Entities.Identity;
using System;

namespace Core.Entities
{
    public class Expense : Title_Content
    {
        public Guid ExpenseID { get; set; }
        public Guid UserID { get; set; }
        public byte[] Image { get; set; }
        public decimal TotalPrice { get; set; }
        public bool IsApproved { get; set; }

        public VetoMessage VetoMessage { get; set; }
        public User User { get; set; }
    }
}

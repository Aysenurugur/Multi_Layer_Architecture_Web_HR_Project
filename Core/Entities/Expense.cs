using Core.Entities.Base_Entities;
using Core.Entities.Identity;

namespace Core.Entities
{
    public class Expense : Title_Content
    {
        public int ExpenseID { get; set; }
        public string UserID { get; set; }
        public int? FileID { get; set; }
        public int? VetoMessageID { get; set; }
        public byte[] Image { get; set; }
        public decimal TotalPrice { get; set; }
        public bool IsApproved { get; set; }

        public File File { get; set; } //nav prop
        public VetoMessage VetoMessage { get; set; }
        public User User { get; set; }
    }
}

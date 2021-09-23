using Core.Entities.Identity;
using System;
using System.Collections.Generic;

namespace Core.Entities
{
    public class File
    {
        public Guid FileID { get; set; } //PK
        public Guid UserID { get; set; } //FK
        public Guid FileTypeID { get; set; } //FK
        public byte[] PDFFile { get; set; }
        public DateTime? CreatedDate { get; set; }

        public FileType FileType { get; set; }
        public User User { get; set; }
        public ICollection<Expense> Expenses { get; set; }
    }
}

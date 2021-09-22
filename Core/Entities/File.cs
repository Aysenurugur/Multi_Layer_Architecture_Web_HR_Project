using Core.Entities.Identity;
using System;
using System.Collections.Generic;

namespace Core.Entities
{
    public class File
    {
        public int FileID { get; set; } //PK
        public string UserID { get; set; } //FK
        public int FileTypeID { get; set; } //FK
        public byte[] PDFFile { get; set; }
        public DateTime? CreatedDate { get; set; }

        public FileType FileType { get; set; }
        public User User { get; set; }
        public ICollection<Expense> Expenses { get; set; }
    }
}

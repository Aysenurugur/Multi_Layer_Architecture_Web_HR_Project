using Core.Entities.Identity;
using System;

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
    }
}

using Data.Entities.Identity;
using System;

namespace Data.Entities
{
    public class File
    {
        public int FileID { get; set; }
        public string UserID { get; set; }
        public int FileTypeID { get; set; }
        public byte[] PDFFile { get; set; }
        public DateTime? CreatedDate { get; set; }

        public FileType FileType { get; set; }
        public User User { get; set; }
    }
}

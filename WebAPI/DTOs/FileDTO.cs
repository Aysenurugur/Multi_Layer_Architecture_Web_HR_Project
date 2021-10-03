using System;

namespace WebAPI.DTOs
{
    public class FileDTO
    {
        public Guid FileID { get; set; } //PK
        public Guid UserID { get; set; } //FK
        public Guid FileTypeID { get; set; } //FK
        public byte[] PDFFile { get; set; }
        public DateTime? CreatedDate { get; set; }
    }
}

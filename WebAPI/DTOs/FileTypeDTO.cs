using System;

namespace WebAPI.DTOs
{
    public class FileTypeDTO
    {
        public Guid FileTypeID { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
    }
}

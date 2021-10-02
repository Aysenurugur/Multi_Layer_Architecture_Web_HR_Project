using System;

namespace WebAPI.DTOs
{
    public class DebitDTO
    {
        public Guid DebitID { get; set; }
        public Guid UserID { get; set; }
        public bool? IsApproved { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public DateTime? CreatedDate { get; set; }
    }
}

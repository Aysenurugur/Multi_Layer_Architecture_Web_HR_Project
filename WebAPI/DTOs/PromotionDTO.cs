using System;

namespace WebAPI.DTOs
{
    public class PromotionDTO
    {
        public Guid PromotionID { get; set; }
        public Guid UserID { get; set; }
        public decimal Amount { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public DateTime? CreatedDate { get; set; }
    }
}

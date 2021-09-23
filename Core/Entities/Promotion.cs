using Core.Entities.Base_Entities;
using Core.Entities.Identity;
using System;

namespace Core.Entities
{
    public class Promotion : Title_Content
    {
        public Guid PromotionID { get; set; }
        public Guid UserID { get; set; }
        public decimal Amount { get; set; }

        public User User { get; set; } //nav prop
    }
}

using Core.Entities.Base_Entities;
using Core.Entities.Identity;
using System;

namespace Core.Entities
{
    public class Promotion : Title_Content
    {
        public int PromotionID { get; set; }
        public string UserID { get; set; }

        public User User { get; set; } //nav prop
    }
}

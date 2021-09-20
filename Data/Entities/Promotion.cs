using Data.Entities.Base_Entities;
using Data.Entities.Identity;
using System;

namespace Data.Entities
{
    public class Promotion : Title_Content
    {
        public int PromotionID { get; set; }
        public string UserID { get; set; }

        public User User { get; set; } //nav prop
    }
}

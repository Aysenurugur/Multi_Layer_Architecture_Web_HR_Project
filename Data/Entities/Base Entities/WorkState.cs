using Data.Entities.Identity;
using System;

namespace Data.Entities.Base_Entities
{
    public abstract class WorkState
    {
        public string UserID { get; set; } //FK
        public DateTime? BeginDate { get; set; }
        public DateTime? EndDate { get; set; }

        public User User { get; set; } //nav prop
    }
}

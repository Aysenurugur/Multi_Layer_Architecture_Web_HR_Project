using Core.Entities.Identity;
using System;

namespace Core.Entities.Base_Entities
{
    public abstract class WorkState
    {
        public Guid UserID { get; set; } //FK
        public DateTime? BeginDate { get; set; }
        public DateTime? EndDate { get; set; }

        public User User { get; set; } //nav prop
    }
}

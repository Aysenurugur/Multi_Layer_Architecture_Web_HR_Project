using Core.Entities.Base_Entities;
using System;

namespace Core.Entities
{
    public class DayOff : WorkState
    {
        public Guid DayOffID { get; set; } //PK
        public Guid DayOffTypeID { get; set; } //FK
        public bool? IsApproved { get; set; }

        public DayOffType DayOffType { get; set; } //nav prop
        public VetoMessage VetoMessage { get; set; }
    }
}

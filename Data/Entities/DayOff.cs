using Data.Entities.Base_Entities;

namespace Data.Entities
{
    public class DayOff : WorkState
    {
        public int DayOffID { get; set; } //PK
        public int DayOffTypeID { get; set; } //FK
        public bool IsApproved { get; set; }
        public int? VetoMessageID { get; set; }

        public DayOffType DayOffType { get; set; } //nav prop
        public VetoMessage VetoMessage { get; set; }
    }
}

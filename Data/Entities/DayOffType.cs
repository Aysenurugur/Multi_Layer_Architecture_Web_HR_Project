using Data.Entities.Base_Entities;
using System.Collections.Generic;

namespace Data.Entities
{
    public class DayOffType : Title_Content
    {
        public int DayOffTypeID { get; set; }
        public short Duration { get; set; }

        public ICollection<DayOff> DayOffs { get; set; }
    }
}

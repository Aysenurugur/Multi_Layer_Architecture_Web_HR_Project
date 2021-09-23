using Core.Entities.Base_Entities;
using System;
using System.Collections.Generic;

namespace Core.Entities
{
    public class DayOffType : Title_Content
    {
        public Guid DayOffTypeID { get; set; }
        public short Duration { get; set; }

        public ICollection<DayOff> DayOffs { get; set; }
    }
}

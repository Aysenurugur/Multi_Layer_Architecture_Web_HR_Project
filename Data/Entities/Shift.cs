﻿using Data.Entities.Base_Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Entities
{
    public class Shift : WorkState
    {
        public int ShiftID { get; set; } //PK
    }
}

﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TimeManager.Data.Model
{
    class AssignedSchedule
    {
        public DateTimeBlock[] DateTimeBlocks { get; set; }
        public Schedule Schedule { get; set; }
    }
}

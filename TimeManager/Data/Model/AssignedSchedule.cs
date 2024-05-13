﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TimeManager.Data.Model
{
    public class AssignedSchedule
    {
        public List<DateTimeBlock> AssignedBlocks { get; set; }
        public long ScheduleId { get; set; }
        public string ScheduleName { get; set; }
    }
}

﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TimeManager.Data.Model;

namespace TimeManager.Scheduler
{
    public interface ISchedulerStrategy
    {
        void Schedule(TimeTable timeTable, List<Task> tasks);
    }
}

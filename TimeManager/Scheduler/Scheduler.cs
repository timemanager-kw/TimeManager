using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TimeManager.Data.Model;

namespace TimeManager.Scheduler
{
    public abstract class Scheduler : IScheduler
    {
        public TimeTable Run()
        {
            AssignSchdules();
            return ScheduleTasks();
        }

        abstract public void AssignSchdules();
        abstract public TimeTable ScheduleTasks();
    }
}

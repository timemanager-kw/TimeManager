using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TimeManager.Data.Model;

namespace TimeManager.Scheduler
{
    public abstract class Scheduler
    {
        public void Run(Week week)
        {
            AssignSchdules(week);
            ScheduleTasks();
        }

        abstract public void AssignSchdules(Week week);
        abstract public void ScheduleTasks();
    }
}

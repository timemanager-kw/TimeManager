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
        public void Run(DateTime limitDate)
        {
            AssignSchdules(limitDate);
            ScheduleTasks();
        }

        abstract public void AssignSchdules(DateTime limitDate);
        abstract public void ScheduleTasks();
    }
}

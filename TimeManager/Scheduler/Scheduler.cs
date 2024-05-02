using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TimeManager.Scheduler
{
    abstract class Scheduler
    {
        public void Run()
        {
            AssignSchdules();
            Schedule();
        }

        abstract public void AssignSchdules();
        abstract public void Schedule();
    }
}

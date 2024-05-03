using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TimeManager.Data.Model;

namespace TimeManager.Scheduler
{
    interface IScheduler
    {
        TimeTable Run();
    }
}

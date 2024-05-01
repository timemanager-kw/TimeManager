using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TimeManager.Data.Model
{
    class TimeTable
    {
        private DateTimeBlock[] AvailableTimes { get; set; }
        private AssignedSchedule[] AssignedSchedules { get; set; }
        private AssignedTask[] AssignedTasks { get; set; }
    }
}

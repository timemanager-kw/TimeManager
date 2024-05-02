using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TimeManager.Data.Model
{
    class TimeTable
    {
        private List<DateTimeBlock> WorkTimes { get; set; }
        private List<AssignedSchedule> AssignedSchedules { get; set; }
        private List<AssignedTask> AssignedTasks { get; set; }
    }
}

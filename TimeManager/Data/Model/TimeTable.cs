using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TimeManager.Data.Model
{
    class TimeTable
    {
        /* private properties */
        private List<DateTimeBlock> _workTimes { get; set; }
        private List<AssignedSchedule> _assignedSchedules { get; set; }
        private List<AssignedTask> _assignedTasks { get; set; }

        /* public readonly properties */
        public List<DateTimeBlock> WorkTimes { get { return _workTimes; } }
        public List<AssignedSchedule> AssignedSchedules { get { return _assignedSchedules; } }
        public List<AssignedTask> AssignedTasks { get { return _assignedTasks; } }

        /* constructor */
        public TimeTable()
        {
            _workTimes = new List<DateTimeBlock>();
            _assignedSchedules = new List<AssignedSchedule>();
            _assignedTasks = new List<AssignedTask>();
        }
        public TimeTable(List<DateTimeBlock> workTimes, List<AssignedSchedule> assignedSchedules, List<AssignedTask> assignedTasks)
        {
            _workTimes = workTimes;
            _assignedSchedules = assignedSchedules;
            _assignedTasks = assignedTasks;
        }
    }
}

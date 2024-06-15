using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TimeManager.Data.Manager;
using TimeManager.Data.Model;

namespace TimeManager.Scheduler
{
    internal class ThunderScheduler : Scheduler
    {
        private ISchedulerStrategy _schedulerStrategy;
        private ITimeTableManager _timeTableManager;
        private IScheduleManager _scheduleManager;
        private ITaskManager _taskManager;

        private TimeTable _timeTable;

        public ThunderScheduler(ThunderSchedulerStrategy thunderSchedulerStrategy,
            ITimeTableManager timeTableManager,
            IScheduleManager scheduleManager,
            ITaskManager taskManager)
        {
            _schedulerStrategy = thunderSchedulerStrategy;
            _timeTableManager = timeTableManager;
            _scheduleManager = scheduleManager;
            _taskManager = taskManager;

            // TODO: 지난 일에 대한 타임테이블은 포함되어 있어야 함 (향후 수정)
            _timeTable = new TimeTable();
        }

        public override void AssignSchdules()
        {
            IEnumerable<Schedule> schedules = _scheduleManager.GetAll();

            throw new NotImplementedException();
        }

        public override void ScheduleTasks()
        {
            IEnumerable<Task> tasks = _taskManager.GetAll();

            throw new NotImplementedException();
        }
    }
}


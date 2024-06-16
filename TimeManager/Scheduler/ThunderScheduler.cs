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
        }


        public void DeleteAllScheduleFromTommorow(TimeTable newTimeTable)
        {
            // newtimeTable에서 오늘 이후의 일정 다 지우기.

            // <DateTimeBlock>List의 크기가 0인 것들을 모아두는 List
            List<AssignedSchedule> delSchedule_list = new List<AssignedSchedule>();

            foreach (AssignedSchedule a_Schedule in newTimeTable.AssignedSchedules)
            {
                List<DateTimeBlock> delBlock_list = new List<DateTimeBlock>();
                // 지울것들을 배열에 넣어놓은 후
                foreach (DateTimeBlock del_dateTime in a_Schedule.AssignedBlocks)
                {
                    // 지울것을 List에 넣어놓기.
                    if (del_dateTime.StartDate.Day > DateTime.Today.Day)
                    {
                        delBlock_list.Add(del_dateTime);
                    }
                }
                // 배열에 있는것들 지우기
                foreach (DateTimeBlock del_element in delBlock_list)
                {
                    a_Schedule.AssignedBlocks.Remove(del_element);
                }
                // 만약 아무것도 들어가있지 않게 되었다면
                if (a_Schedule.AssignedBlocks.Count == 0)
                {
                    // List에 추가
                    delSchedule_list.Add(a_Schedule);
                }
            }

            // 0개 List를 갖고 있는 AssignedSchedule 지우기
            foreach (AssignedSchedule del_element in delSchedule_list)
            {
                newTimeTable.AssignedSchedules.Remove(del_element);
            }
        }























        public override void AssignSchdules()
        {

            _timeTable = _timeTableManager.Get();

            // _timeTable의 복사본  - new TimeTable
            TimeTable newTimeTable = new TimeTable(_timeTable.WorkTimes, _timeTable.AssignedSchedules, _timeTable.AssignedTasks);

            IEnumerable<Schedule> schedules = _scheduleManager.GetAll();

            // newtimeTable에서 오늘 이후의 일정 다 지우기.
            DeleteAllScheduleFromTommorow(newTimeTable);

            // 오늘로부터의 Schedule 모두 넣기
            foreach (Schedule schedule in schedules)
            {
                // schedule이 오늘 이후의 것들이라면 가져옴.
                if(schedule.TimeBlock.StartDate.Day > DateTime.Today.Day)
                {
                    AssignedSchedule assignedSchedule = new AssignedSchedule();
                    assignedSchedule.AssignedBlocks.Add(new DateTimeBlock(schedule.TimeBlock.StartDate, schedule.TimeBlock.EndDate));
                    assignedSchedule.ScheduleId = schedule.Id;
                    //assignedSchedule.ScheduleName = schedule.Name;

                    newTimeTable.AssignedSchedules.Add(assignedSchedule);
                }
            }

            _timeTable = newTimeTable;
        }

        public override void ScheduleTasks()
        {
            IEnumerable<Task> tasks = _taskManager.GetAll();

            throw new NotImplementedException();

            _timeTableManager.Save(_timeTable);
        }
    }
}

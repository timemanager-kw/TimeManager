using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
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

        public void DeleteAllTaskFromTomorrow(TimeTable newTimeTable)
        {
            List<AssignedTask> delTask_list = new List<AssignedTask>();

            foreach (AssignedTask a_Task in newTimeTable.AssignedTasks)
            {
                List<DateTimeBlock> delBlock_list = new List<DateTimeBlock>();

                foreach (DateTimeBlock del_dateTime in a_Task.AssignedBlocks)
                {
                    if (del_dateTime.StartDate.Date > DateTime.Today.Date)
                    {
                        delBlock_list.Add(del_dateTime);
                    }
                }

                foreach (DateTimeBlock del_element in delBlock_list)
                {
                    a_Task.AssignedBlocks.Remove(del_element);
                }
                if (a_Task.AssignedBlocks.Count == 0)
                {
                    // List에 추가
                    delTask_list.Add(a_Task);
                }
            }
            foreach (AssignedTask del_element in delTask_list)
            {
                newTimeTable.AssignedTasks.Remove(del_element);
            }
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
                    if (del_dateTime.StartDate.Date > DateTime.Today.Date)
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
                newTimeTable.UnassignSchedule(del_element.ScheduleId);
            }
        }

        public override void AssignSchdules(Week week)
        {
            _timeTable = _timeTableManager.Get();
            List<Schedule> schedules = _scheduleManager.GetAll().ToList();
            foreach (Schedule schedule in schedules)
            {
                if (schedule.Type == EScheduleType.Regular)
                {
                    List<DateTimeBlock> dateTimeBlocks = new List<DateTimeBlock>();
                    for (int i = 0; i < schedule.RegularTimeBlocks.Count; i++)
                    {
                        WeeklyDateTimeBlock weeklyDateTimeBlock = schedule.RegularTimeBlocks[i];

                        DateTime dateTime = week.GetDay(weeklyDateTimeBlock.DayOfWeek == DayOfWeek.Sunday ? 6 : (int)weeklyDateTimeBlock.DayOfWeek - 1);

                        weeklyDateTimeBlock.StartTime = new DateTime(dateTime.Year, dateTime.Month, dateTime.Day, weeklyDateTimeBlock.StartTime.Hour, weeklyDateTimeBlock.StartTime.Minute, weeklyDateTimeBlock.StartTime.Second);
                        weeklyDateTimeBlock.EndTime = new DateTime(dateTime.Year, dateTime.Month, dateTime.Day, weeklyDateTimeBlock.EndTime.Hour, weeklyDateTimeBlock.EndTime.Minute, weeklyDateTimeBlock.EndTime.Second);
                        schedule.RegularTimeBlocks[i] = weeklyDateTimeBlock;

                        dateTimeBlocks.Add(new DateTimeBlock(weeklyDateTimeBlock.StartTime, weeklyDateTimeBlock.EndTime));
                    }

                    try
                    {
                        _scheduleManager.Update(schedule);
                        _timeTable.ReassignSchedule(schedule.Id, dateTimeBlocks);
                        _timeTableManager.Save(_timeTable);
                    }
                    catch (ArgumentException ex) { }
                }
            }
        }


        public DateTime ChangeToFocusDate(DateTime endDate, int focusDays)
        {
            throw new NotImplementedException();
        }

        public int ChangeToFocusDays(DateTime endDate, DateTime todayDate)
        {
            
            return (endDate - todayDate).Days;
        }


        public override void ScheduleTasks()
        {
            TimeTable newTimeTable = new TimeTable(_timeTable.WorkTimes, _timeTable.AssignedSchedules, _timeTable.AssignedTasks);
            DeleteAllTaskFromTomorrow(newTimeTable);

            List<Task> tasks______________ = (List<Task>)_taskManager.GetAll();
            List<AssignedTask> assignedTasks = _timeTable.GetAllAssignedTasks();
            // tasks의 복사본 필요. -> repTasks
            List<Task> repTasks = new List<Task>();

            foreach(Task task in tasks______________)
            {
                Task task_ = new Task();
                task_.Id = task.Id;
                task_.Name = task.Name;
                task_.Description = task.Description;
                task_.StartDate = task.StartDate;
                task_.FocusDays = task.FocusDays;
                task_.EndDate = task.EndDate;
                task_.Duration = task.Duration;
                task_.Type = task.Type;
                task_.WeeklyTimesWanted = task.WeeklyTimesWanted;

                repTasks.Add(task_);
            }
            
            // ShortTerm에 대해 focus date 조정, duration 조정
            foreach (Task repTask in repTasks)
            {
                if (repTask.Type == ETaskType.LongTerm)
                {
                    if (repTask.EndDate?.Date <= DateTime.Today.Date)
                        continue;

                    // FocusDays 변경
                    if (repTask.EndDate?.AddDays(-(double)(repTask.FocusDays - 1)) <= DateTime.Now.Date)
                        repTask.FocusDays = ChangeToFocusDays(repTask.EndDate.GetValueOrDefault(), DateTime.Now.Date);

                    // Duration 변경(앞에 사용된 시간만큼 줄이기)
                    foreach (AssignedTask assignedTask in assignedTasks)
                    {
                        foreach (DateTimeBlock timeBlock in assignedTask.AssignedBlocks)
                        {
                            //timeBlock이 내일 전인 것들을 찾는다.
                            if (timeBlock.EndDate.Date <= DateTime.Today.Date)
                            {
                                // 그 시간블럭 크기만큼 줄인다.
                                repTask.Duration -= timeBlock.Duration;
                            }
                        }
                    }
                }
                else
                {
                    continue;
                }
            }
            _schedulerStrategy.Schedule(_timeTable, repTasks);


            _timeTableManager.Save(_timeTable);
        }
    }
}

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
                if(schedule.TimeBlock.StartDate.Date > DateTime.Today.Date)
                {
                    AssignedSchedule assignedSchedule = new AssignedSchedule();
                    assignedSchedule.AssignedBlocks.Add(new DateTimeBlock(schedule.TimeBlock.StartDate, schedule.TimeBlock.EndDate));
                    assignedSchedule.ScheduleId = schedule.Id;
                    assignedSchedule.ScheduleName = schedule.Name;

                    newTimeTable.AssignedSchedules.Add(assignedSchedule);
                }
            }

            _timeTable = newTimeTable;
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
            List<Task> tasks______________ = (List<Task>)_taskManager.GetAll();

            // tasks의 복사본 필요. -> repTasks
            List<Task> repTasks = new List<Task>();

            foreach(Task task in tasks______________)
            {
                Task task_ = new Task();
                task_.Id = task.Id;
                task_.Name = task.Name;
                task_.FocusDays = task.FocusDays;
                task_.EndDate = task.EndDate;
                task_.Duration = task.Duration;
                task_.Type = task.Type;

                repTasks.Add(task_);
            }

            // ShortTerm에 대해 focus date 조정, duration 조정
            foreach (Task repTask in repTasks)
            {
                if (repTask.Type == ETaskType.LongTerm)
                    continue;
                if (repTask.EndDate?.Date <= DateTime.Today.Date)
                    continue;
                // Shortterm에 대해 할것임. (& 마감일이 내일 이후인 것들만 확인할 것임.)

                AssignedTask as_task;

                // AssignedTasks에서 assignedTask의 DateTimeBlock들을 확인할것임 
                // DateTimeBlock에서 '내일 전'의 일정들에 할당된 시간만큼 지우기.
                
                foreach (AssignedTask assignedTask in _timeTable.AssignedTasks)
                {
                    if(assignedTask.TaskId == repTask.Id)
                    {
                        as_task = assignedTask;
                        break;
                    }
                }
                // FocusDays 변경
                repTask.FocusDays = ChangeToFocusDays(repTask.EndDate.GetValueOrDefault(), DateTime.Now.Date);

                // Duration 변경(앞에 사용된 시간만큼 줄이기)
                foreach (AssignedTask assignedTask in _timeTable.AssignedTasks)
                {
                    foreach(DateTimeBlock timeBlock in assignedTask.AssignedBlocks)
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

            _schedulerStrategy.Schedule(_timeTable, repTasks);


            /*여기서부터 longTerm에 대해서 만들기*/
            // 요일별로만 따지는것이므로 아마 앞의 것들을 볼 필요 없이 그대로 가면 될듯


            _timeTableManager.Save(_timeTable);
        }
    }
}

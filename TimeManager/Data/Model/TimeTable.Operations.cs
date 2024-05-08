using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TimeManager.Data.Model
{
    partial class TimeTable : ITimeTable
    {
        public void AssignSchedule(long scheduleId, IEnumerable<DateTimeBlock> assignedTimeBlocks)
        {
            throw new NotImplementedException();
        }

        public void AssignTask(long taskId, IEnumerable<DateTimeBlock> assignedTimeBlocks)
        {
            throw new NotImplementedException();
        }

        public List<AssignedSchedule> GetAllAssignedSchedules()
        {
            throw new NotImplementedException();
        }

        public List<AssignedSchedule> GetAllAssignedSchedulesAsOfNow()
        {
            throw new NotImplementedException();
        }

        public List<AssignedTask> GetAllAssignedTasks()
        {
            throw new NotImplementedException();
        }

        public List<AssignedTask> GetAllAssignedTasksAsOfNow()
        {
            throw new NotImplementedException();
        }

        public List<AssignedSchedule> GetAssignedSchedulesByScheduleId(long scheduleId)
        {
            throw new NotImplementedException();
        }

        public List<AssignedSchedule> GetAssignedSchedulesInBlock(DateTimeBlock timeBlock)
        {
            throw new NotImplementedException();
        }

        public List<AssignedSchedule> GetAssignedSchedulesInThisWeekAsOfNow()
        {
            throw new NotImplementedException();
        }

        public List<AssignedTask> GetAssignedTasksByTaskId(long taskId)
        {
            throw new NotImplementedException();
        }

        public List<AssignedTask> GetAssignedTasksInBlock(DateTimeBlock timeBlock)
        {
            throw new NotImplementedException();
        }

        public List<AssignedTask> GetAssignedTasksInThisWeekAsOfNow()
        {
            throw new NotImplementedException();
        }

        public List<DateTimeBlock> GetAvailableTimesInThisWeekAsOfNow()
        {
            throw new NotImplementedException();
        }

        public List<AssignedSchedule> GetWeeklyAssignedSchedules(Week week)
        {
            throw new NotImplementedException();
        }

        public List<AssignedTask> GetWeeklyAssignedTasks(Week week)
        {
            throw new NotImplementedException();
        }

        public List<DateTimeBlock> GetWeeklyAvailableTimes(Week week)
        {
            throw new NotImplementedException();
        }

        public List<DateTimeBlock> GetWorkTimes()
        {
            throw new NotImplementedException();
        }

        public bool IsAvailable(DateTimeBlock timeBlock)
        {
            throw new NotImplementedException();
        }

        public void ReassignSchedule(long scheduleId, IEnumerable<DateTimeBlock> assignedTimeBlocks)
        {
            throw new NotImplementedException();
        }

        public void ReassignTask(long taskId, IEnumerable<DateTimeBlock> assignedTimeBlocks)
        {
            throw new NotImplementedException();
        }

        public void SetWorkTimes(List<DateTimeBlock> workTimes)
        {
            throw new NotImplementedException();
        }

        public void UnassignSchedule(long scheduleId)
        {
            throw new NotImplementedException();
        }

        public void UnassignTask(long taskId)
        {
            throw new NotImplementedException();
        }
    }
}

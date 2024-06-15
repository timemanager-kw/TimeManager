using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TimeManager.Data.Model
{
    public partial class TimeTable : ITimeTable
    {
        private TimeTable timetable = new TimeTable();
        /* AssignedTask Operations */
        public void AssignTask(long taskId, IEnumerable<DateTimeBlock> assignedTimeBlocks)
        {
           if(timetable.AssignedTasks.Any(t =>t.TaskId == taskId))
            {
                throw new ArgumentException("이미 있는 task입니다.");
            }
            var newTask = new AssignedTask(assignedTimeBlocks.ToList(), taskId);
            timetable.AssignedTasks.Add(newTask); 
        }

        public void ReassignTask(long taskId, IEnumerable<DateTimeBlock> assignedTimeBlocks)
        {
            
        }

        public void UnassignTask(long taskId)
        {
            throw new NotImplementedException();
        }

        public List<AssignedTask> GetAssignedTasksByTaskId(long taskId)
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

        public List<AssignedTask> GetWeeklyAssignedTasks(Week week)
        {
            return _assignedTasks
                .Where(t => t.AssignedBlocks.Any(b => week.IsInWeek(b.StartDate)))
                .ToList();
        }

        public List<AssignedTask> GetAssignedTasksInThisWeekAsOfNow()
        {
            throw new NotImplementedException();
        }
        
        public List<AssignedTask> GetAssignedTasksInBlock(DateTimeBlock timeBlock)
        {
            throw new NotImplementedException();
        }
    }
}

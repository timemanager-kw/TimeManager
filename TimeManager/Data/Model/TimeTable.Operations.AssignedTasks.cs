using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TimeManager.Data.Model
{
    public partial class TimeTable : ITimeTable
    {
        private TimeTable timeTable = new TimeTable();
        /* AssignedTask Operations */
        public void AssignTask(long taskId, IEnumerable<DateTimeBlock> assignedTimeBlocks)
        {
           if(timeTable.AssignedTasks.Any(t =>t.TaskId == taskId))
            {
                throw new ArgumentException("이미 있는 task입니다.");
            }
            var newTask = new AssignedTask(assignedTimeBlocks.ToList(), taskId);
            timeTable.AssignedTasks.Add(newTask); 
        }

        public void ReassignTask(long taskId, IEnumerable<DateTimeBlock> assignedTimeBlocks)
        {
            var task = timeTable.AssignedTasks.FirstOrDefault(t=>t.TaskId == taskId);
            if(task != null)
            {
                task.AssignedBlocks.Clear();
                var newTask = new AssignedTask(assignedTimeBlocks.ToList(), taskId);
                timeTable.AssignedTasks.Add(newTask);
            }
            else
            {
                throw new ArgumentException("taskId에 해당하는 task가 없습니다.");
            }
        }

        public void UnassignTask(long taskId)
        {
            var taskToRemove = timeTable.AssignedTasks.FirstOrDefault(t => t.TaskId == taskId);
            if(taskToRemove != null)
            {
                timeTable.AssignedTasks.Remove(taskToRemove);
            }
            else
            {
                throw new ArgumentException("taskId에 해당하는 task가 없습니다.");
            }
        }

        public List<AssignedTask> GetAssignedTasksByTaskId(long taskId)
        {
            return timeTable.AssignedTasks.Where(t=>t.TaskId == taskId).ToList();
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

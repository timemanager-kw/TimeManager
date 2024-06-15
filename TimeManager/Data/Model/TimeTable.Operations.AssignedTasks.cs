using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TimeManager.Data.Model
{
    public partial class TimeTable : ITimeTable
    {
        /* AssignedTask Operations */
        public void AssignTask(long taskId, IEnumerable<DateTimeBlock> assignedTimeBlocks)
        {
           if(_assignedTasks.Any(t =>t.TaskId == taskId))
            {
                throw new ArgumentException("이미 있는 task입니다.");
            }
            var newTask = new AssignedTask(assignedTimeBlocks.ToList(), taskId);
            _assignedTasks.Add(newTask); 
        }

        public void ReassignTask(long taskId, IEnumerable<DateTimeBlock> assignedTimeBlocks)
        {
            var task = _assignedTasks.FirstOrDefault(t=>t.TaskId == taskId);
            if(task != null)
            {
                task.AssignedBlocks.Clear();
                var newTask = new AssignedTask(assignedTimeBlocks.ToList(), taskId);
                _assignedTasks.Add(newTask);
            }
            else
            {
                throw new ArgumentException("taskId에 해당하는 task가 없습니다.");
            }
        }

        public void UnassignTask(long taskId)
        {
            var taskToRemove = _assignedTasks.FirstOrDefault(t => t.TaskId == taskId);
            if(taskToRemove != null)
            {
                _assignedTasks.Remove(taskToRemove);
            }
            else
            {
                throw new ArgumentException("taskId에 해당하는 task가 없습니다.");
            }
        }

        public List<AssignedTask> GetAssignedTasksByTaskId(long taskId)
        {
            return _assignedTasks.Where(t=>t.TaskId == taskId).ToList();
        }

        public List<AssignedTask> GetAllAssignedTasks()
        {
            return _assignedTasks;
        }

        public List<AssignedTask> GetAllAssignedTasksAsOfNow()
        {
            var now = DateTime.Now;
            return _assignedTasks.Where(task => task.AssignedBlocks.Any(block => block.StartDate <= now && block.EndDate >= now)).ToList();
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

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TimeManager.Data.Model
{
    public partial class TimeTable : ITimeTable
    {
        /* AssignedTask Operations */
        public void AssignTask(long taskId, IEnumerable<DateTimeBlock> assignedTimeBlocks)
        {
            throw new NotImplementedException();
        }

        public void ReassignTask(long taskId, IEnumerable<DateTimeBlock> assignedTimeBlocks)
        {
            throw new NotImplementedException();
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

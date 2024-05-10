using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TimeManager.Data.Model
{
    partial class TimeTable : ITimeTable
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
            throw new NotImplementedException();
        }

        public List<AssignedTask> GetAssignedTasksInThisWeekAsOfNow()
        {
            throw new NotImplementedException();
        }
        
        public List<AssignedTask> GetAssignedTasksInBlock(DateTimeBlock timeBlock)
        {
            throw new NotImplementedException();
        }

        private List<DateTimeBlock> GetDailyAssignedTasks(DateTime date)
        {
            throw new NotImplementedException();
        }

    }
}

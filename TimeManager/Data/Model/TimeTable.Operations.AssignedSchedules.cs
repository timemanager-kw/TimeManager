using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TimeManager.Data.Model
{
    partial class TimeTable : ITimeTable
    {
        /* AssignedSchedule Operations */
        public void AssignSchedule(long scheduleId, IEnumerable<DateTimeBlock> assignedTimeBlocks)
        {
            throw new NotImplementedException();
        }
        public void ReassignSchedule(long scheduleId, IEnumerable<DateTimeBlock> assignedTimeBlocks)
        {
            throw new NotImplementedException();
        }

        public void UnassignSchedule(long scheduleId)
        {
            throw new NotImplementedException();
        }

        public List<AssignedSchedule> GetAllAssignedSchedules()
        {
            throw new NotImplementedException();
        }

        public List<AssignedSchedule> GetAssignedSchedulesByScheduleId(long scheduleId)
        {
            throw new NotImplementedException();
        }

        public List<AssignedSchedule> GetAllAssignedSchedulesAsOfNow()
        {
            throw new NotImplementedException();
        }

        public List<AssignedSchedule> GetWeeklyAssignedSchedules(Week week)
        {
            throw new NotImplementedException();
        }

        public List<AssignedSchedule> GetAssignedSchedulesInThisWeekAsOfNow()
        {
            throw new NotImplementedException();
        }

        public List<AssignedSchedule> GetAssignedSchedulesInBlock(DateTimeBlock timeBlock)
        {
            throw new NotImplementedException();
        }

        private List<DateTimeBlock> GetDailyAssignedSchedules(DateTime date)
        {
            throw new NotImplementedException();
        }
    }
}

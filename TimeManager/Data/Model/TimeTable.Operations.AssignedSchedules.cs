using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TimeManager.Data.Model
{
    public partial class TimeTable : ITimeTable
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
            return _assignedSchedules
                .Where(s => s.AssignedBlocks.Any(b => week.IsInWeek(b.StartDate)))
                .ToList();
        }

        public List<AssignedSchedule> GetAssignedSchedulesInThisWeekAsOfNow()
        {
            throw new NotImplementedException();
        }

        public List<AssignedSchedule> GetAssignedSchedulesInBlock(DateTimeBlock timeBlock)
        {
            throw new NotImplementedException();
        }

        private List<AssignedSchedule> GetDailyAssignedSchedules(DateTime date)
        {
            throw new NotImplementedException();
        }
    }
}

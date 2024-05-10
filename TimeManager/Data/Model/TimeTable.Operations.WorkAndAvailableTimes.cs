using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TimeManager.Data.Model
{
    partial class TimeTable : ITimeTable
    {
        /* WorkTime Operations */
        // TODO: 주 단위로 확장
        public void SetWorkTimes(List<DateTimeBlock> workTimes)
        {
            _workTimes = workTimes;
        }

        public List<DateTimeBlock> GetWorkTimes()
        {
            return _workTimes;
        }


        /* AvailableTime Operations */
        public List<DateTimeBlock> GetWeeklyAvailableTimes(Week week)
        {
            IEnumerable<DateTimeBlock> scheduleTimes = GetWeeklyAssignedSchedules(week)
                .SelectMany(s => s.AssignedBlocks);

            return (List<DateTimeBlock>) DateTimeBlock.Difference(_workTimes, scheduleTimes);
        }

        public List<DateTimeBlock> GetAvailableTimesInThisWeekAsOfNow()
        {
            IEnumerable<DateTimeBlock> scheduleTimesInThisWeek = GetAssignedSchedulesInThisWeekAsOfNow()
                .SelectMany(s => s.AssignedBlocks);

            return (List<DateTimeBlock>) DateTimeBlock.Difference(scheduleTimesInThisWeek, _workTimes);
        }
        
        public bool IsAvailable(DateTimeBlock timeBlock)
        {
            throw new NotImplementedException();
        }
        
    }
}

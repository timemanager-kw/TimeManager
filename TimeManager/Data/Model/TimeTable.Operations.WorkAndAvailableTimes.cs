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
            throw new NotImplementedException();
        }

        public List<DateTimeBlock> GetAvailableTimesInThisWeekAsOfNow()
        {
            throw new NotImplementedException();
        }
        
        public bool IsAvailable(DateTimeBlock timeBlock)
        {
            throw new NotImplementedException();
        }
        
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TimeManager.Extensions
{
    public static class DayOfWeekExtension
    {
        public static int GetDayOfWeekIndexStartedFrom(this DayOfWeek dayOfWeek, DayOfWeek start = DayOfWeek.Monday)
        {
            return (7 + (dayOfWeek - start)) % 7;
        }
    }
}

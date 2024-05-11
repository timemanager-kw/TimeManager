using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TimeManager.Extensions;

namespace TimeManager.Data.Model
{
    struct Week
    {
        public int Year { get; set; }
        public int Month { get; set; }
        public int WeekOfMonth { get; set; }


        public static Week From(DateTime dateTime)
        {
            DateTime startOfWeek = dateTime.StartOfWeek();
            return new Week {
                Year = dateTime.Year,
                Month = startOfWeek.Month,
                WeekOfMonth = (startOfWeek.Day - startOfWeek.FirstDayOfMonthHasDayOfWeek(DayOfWeek.Monday).Day) / 7 + 1
            };
        }
    }
}

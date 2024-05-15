using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TimeManager.Extensions;

namespace TimeManager.Data.Model
{
    public struct Week
    {
        public int Year { get; set; }
        public int Month { get; set; }
        public int WeekOfMonth { get; set; }


        public Week PreviousWeek
        {
            get
            {
                DateTime startOfWeek = new DateTime(Year, Month, 1).FirstDayOfMonthHasDayOfWeek(DayOfWeek.Monday).AddDays((WeekOfMonth - 1) * 7);
                DateTime previousWeek = startOfWeek.AddDays(-7);
                return Week.From(previousWeek);
            }
        }


        public static Week From(DateTime dateTime)
        {
            DateTime startOfWeek = dateTime.StartOfWeek();
            return new Week {
                Year = dateTime.Year,
                Month = startOfWeek.Month,
                WeekOfMonth = (startOfWeek.Day - startOfWeek.FirstDayOfMonthHasDayOfWeek(DayOfWeek.Monday).Day) / 7 + 1
            };
        }

        public bool IsInWeek(DateTime dateTime)
        {
            DateTime startOfWeek = new DateTime(Year, Month, 1).FirstDayOfMonthHasDayOfWeek(DayOfWeek.Monday).AddDays((WeekOfMonth - 1) * 7);
            DateTime endOfWeek = startOfWeek.AddDays(7);
            return dateTime >= startOfWeek && dateTime < endOfWeek;
        }
    }
}

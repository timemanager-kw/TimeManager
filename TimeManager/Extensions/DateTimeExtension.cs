using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TimeManager.Extensions
{
    public static class DateTimeExtension
    {
        public static DateTime StartOfWeek(this DateTime dateTime, DayOfWeek startDayOfWeek = DayOfWeek.Monday)
        {
            int diff = (7 + (dateTime.DayOfWeek - startDayOfWeek)) % 7;
            return dateTime.AddDays(-1 * diff).Date;
        }

        public static DateTime EndOfWeek(this DateTime dateTime, DayOfWeek startDayOfWeek = DayOfWeek.Monday)
        {
            return dateTime.StartOfWeek(startDayOfWeek).AddDays(6);
        }

        public static DateTime StartOfMonth(this DateTime dateTime)
        {
            return new DateTime(dateTime.Year, dateTime.Month, 1);
        }

        public static DateTime EndOfMonth(this DateTime dateTime)
        {
            return dateTime.StartOfMonth().AddMonths(1).AddDays(-1);
        }

        public static DateTime FirstDayOfMonthHasDayOfWeek(this DateTime dateTime, DayOfWeek dayOfWeek)
        {
            DateTime firstDayOfMonth = dateTime.StartOfMonth();
            int diff = (7 + (dayOfWeek - firstDayOfMonth.DayOfWeek)) % 7;
            return firstDayOfMonth.AddDays(diff);
        }

        public static DateTime StartOfDay(this DateTime dateTime)
        {
            return new DateTime(dateTime.Year, dateTime.Month, dateTime.Day, 0, 0, 0);
        }

        public static DateTime EndOfDay(this DateTime dateTime)
        {
            return new DateTime(dateTime.Year, dateTime.Month, dateTime.Day, 23, 59, 59);
        }

        public static int GetDayOfWeekIndex(this DateTime dateTime, DayOfWeek startDayOfWeek)
        {
            return (7 + (dateTime.DayOfWeek - startDayOfWeek)) % 7;
        }
    }
}

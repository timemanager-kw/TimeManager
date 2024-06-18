using System;
using System.Collections.Generic;
using System.Diagnostics.Tracing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TimeManager.Extensions;

namespace TimeManager.Data.Model
{
    public partial class TimeTable : ITimeTable
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

        public List<WeeklyDateTimeBlock> GetWeeklyWorkTimes(Week week)
        {
            if (_workTimes == null || _workTimes.Count == 0)
                return new List<WeeklyDateTimeBlock>();

            return _GetWeeklyWorkTimes(week);
        }

        private List<WeeklyDateTimeBlock> _GetWeeklyWorkTimes(Week week, int maxWeek = 48)
        {
            if (maxWeek < 1)
                return new List<WeeklyDateTimeBlock>();

            List<WeeklyDateTimeBlock> weeklyWorkTimes = _workTimes
                .FindAll(b => week.IsInWeek(b.StartDate))
                .Select(b => new WeeklyDateTimeBlock
                {
                    DayOfWeek = b.StartDate.DayOfWeek,
                    StartTime = b.StartDate,
                    EndTime = b.EndDate
                })
                .ToList();

            if (weeklyWorkTimes.Count == 0)
                return _GetWeeklyWorkTimes(week.PreviousWeek, maxWeek - 1);

            return weeklyWorkTimes;
        }


        /* AvailableTime Operations */
        public List<DateTimeBlock> GetWeeklyAvailableTimes(Week week)
        {
            IEnumerable<DateTimeBlock> scheduleTimes = GetWeeklyAssignedSchedules(week)
                .SelectMany(s => s.AssignedBlocks);

            List<WeeklyDateTimeBlock> weeklyWorkTimes = GetWeeklyWorkTimes(Week.From(DateTime.Now));
            List<DateTimeBlock> workTimes = weeklyWorkTimes.Select(w => new DateTimeBlock(
                DateTime.Today.StartOfWeek().AddDays(w.DayOfWeek.GetDayOfWeekIndex()) + w.StartTime.TimeOfDay,
                DateTime.Today.StartOfWeek().AddDays(w.DayOfWeek.GetDayOfWeekIndex()) + w.EndTime.TimeOfDay
            )).ToList();

            return (List<DateTimeBlock>) DateTimeBlock.Difference(workTimes, scheduleTimes);
        }

        public List<DateTimeBlock> GetAvailableTimesInThisWeekAsOfNow()
        {
            IEnumerable<DateTimeBlock> scheduleTimesInThisWeek = GetAssignedSchedulesInThisWeekAsOfNow()
                .SelectMany(s => s.AssignedBlocks);

            List<WeeklyDateTimeBlock> weeklyWorkTimes = GetWeeklyWorkTimes(Week.From(DateTime.Now));
            List<DateTimeBlock> workTimes = weeklyWorkTimes.Select(w => new DateTimeBlock(
                DateTime.Today.StartOfWeek().AddDays(w.DayOfWeek.GetDayOfWeekIndex()) + w.StartTime.TimeOfDay, 
                DateTime.Today.StartOfWeek().AddDays(w.DayOfWeek.GetDayOfWeekIndex()) + w.EndTime.TimeOfDay
            )).ToList();

            return (List<DateTimeBlock>) DateTimeBlock.Difference(workTimes, scheduleTimesInThisWeek);
        }
        
        public bool IsAvailable(DateTimeBlock timeBlock)
        {
            if (timeBlock.StartDate.ToString("yyyy-MM-dd") != timeBlock.EndDate.ToString("yyyy-MM-dd"))
            {
                // TODO: 여러 날짜에 걸친 TimeBlock 처리 지원 
                throw new ArgumentException("TimeBlock should be in the same day.");
            }

            IEnumerable<DateTimeBlock> availableTimes = GetDailyAvailableTimes(timeBlock.StartDate);
            return availableTimes.Any(t => t.StartDate <= timeBlock.StartDate && t.EndDate >= timeBlock.EndDate);
        }

        public List<DateTimeBlock> GetDailyAvailableTimes(DateTime date)
        {
            if (_workTimes == null || _workTimes.Count == 0)
                return new List<DateTimeBlock>();

            IEnumerable<DateTimeBlock> scheduleTimes = GetDailyAssignedSchedules(date)
                .SelectMany(s => s.AssignedBlocks);

            IEnumerable<DateTimeBlock> dailyWorkTimes = _workTimes
                .Where(b => b.StartDate.Date == date.Date);

            if (dailyWorkTimes.Count() == 0)
                return GetDailyAvailableTimes(date.AddDays(-7));

            return (List<DateTimeBlock>) DateTimeBlock.Difference(dailyWorkTimes, scheduleTimes);
        }

        public List<DateTimeBlock> GetAvailableTimesInBlock(DateTimeBlock timeBlock)
        {
            List<DateTimeBlock> availableTimes = new List<DateTimeBlock>();

            for (DateTime date = timeBlock.StartDate.StartOfDay(); date < timeBlock.EndDate.EndOfDay(); date = date.AddDays(1))
            {
                availableTimes.AddRange(GetDailyAvailableTimes(date));
            }

            availableTimes = DateTimeBlock.Difference(availableTimes, 
                new List<DateTimeBlock> { 
                    new DateTimeBlock(timeBlock.StartDate.StartOfDay(), timeBlock.StartDate),
                    new DateTimeBlock(timeBlock.EndDate, timeBlock.EndDate.AddDays(1).StartOfDay())
                }).ToList();

            return availableTimes;
        }
        
    }
}

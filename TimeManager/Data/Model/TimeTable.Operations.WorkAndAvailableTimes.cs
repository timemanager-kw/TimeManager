﻿using System;
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

        public List<DateTimeBlock> GetDailyAvailableTimes(DateTime date)
        {
            if (_workTimes == null || _workTimes.Count == 0)
                return new List<DateTimeBlock>();

            return _GetDailyAvailableTimes(date, date);
        }

        private List<DateTimeBlock> _GetDailyAvailableTimes(DateTime date, DateTime originalDate, int currWeek = 0)
        {
            if (currWeek < -48)
                return new List<DateTimeBlock>();

            List<DateTimeBlock> scheduleTimes = GetDailyAssignedSchedules(originalDate)
                .SelectMany(s => s.AssignedBlocks).ToList();

            List<DateTimeBlock> dailyWorkTimes = _workTimes
                .Where(b => b.StartDate.Date == date.Date)
                .Select(b => new DateTimeBlock(b.StartDate.AddDays(-(currWeek * 7)), b.EndDate.AddDays(-(currWeek * 7)))).ToList();

            if (dailyWorkTimes.Count() == 0)
                return _GetDailyAvailableTimes(date.AddDays(-7), originalDate, currWeek - 1);

            return (List<DateTimeBlock>)DateTimeBlock.Difference(dailyWorkTimes, scheduleTimes);
        }

        public List<DateTimeBlock> GetAvailableTimesInDaysBlock(DateTimeBlock timeBlock)
        {
            List<DateTimeBlock> availableTimes = new List<DateTimeBlock>();

            for (DateTime date = timeBlock.StartDate.StartOfDay(); date < timeBlock.EndDate.EndOfDay(); date = date.AddDays(1))
            {
                availableTimes.AddRange(GetDailyAvailableTimes(date));
            }

            return availableTimes;
        }
        
    }
}

﻿using System;
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
            if(_assignedSchedules.Any(s=>s.ScheduleId == scheduleId))
            {
                throw new ArgumentException("이미 있는 schedule입니다.");
            }
            var newSchedule = new AssignedSchedule(assignedTimeBlocks.ToList(), scheduleId);
            _assignedSchedules.Add(newSchedule);
        }
        public void ReassignSchedule(long scheduleId, IEnumerable<DateTimeBlock> assignedTimeBlocks)
        {
            var schedule = _assignedSchedules.FirstOrDefault(s=>s.ScheduleId == scheduleId);
            if (schedule != null)
            {
                schedule.AssignedBlocks.Clear();
                var newSchedule = new AssignedSchedule(assignedTimeBlocks.ToList(), scheduleId);
                _assignedSchedules.Add(newSchedule);
            }
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

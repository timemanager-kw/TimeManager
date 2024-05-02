using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TimeManager.Data.Model
{
    class Task
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public TimeSpan? Duration { get; set; }
        public int? FocusDays { get; set; }
        public List<WeeklyDateTimeBlock> WeeklyTimesWanted { get; set; }
        public int? NDaysOfWeekWanted { get; set; }

    }
}

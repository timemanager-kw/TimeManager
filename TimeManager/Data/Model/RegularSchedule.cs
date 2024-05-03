using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TimeManager.Data.Model
{
    class RegularSchedule : Schedule
    {
        public List<WeeklyDateTimeBlock> WeeklyDateTimeBlocks { get; set; }
    }
}

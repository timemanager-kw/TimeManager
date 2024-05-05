using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TimeManager.Data.Model
{
    class AssignedSchedule
    {
        public List<DateTimeBlock> DateTimeBlocks { get; set; }
        public long ScheduleId { get; set; }
    }
}

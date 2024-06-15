using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TimeManager.Data.Model
{
    public class AssignedSchedule
    {
        public AssignedSchedule(List<DateTimeBlock> assignedblocks, long scheduleid, string schedulename) {
            AssignedBlocks = assignedblocks;
            ScheduleId = scheduleid;
        }
        public List<DateTimeBlock> AssignedBlocks { get; set; }
        public long ScheduleId { get; set; }

        public AssignedSchedule()
        {
            AssignedBlocks = new List<DateTimeBlock>();
        }
    }
}

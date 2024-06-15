using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TimeManager.Data.Model
{
    public class AssignedTask
    {
        public AssignedTask(List<DateTimeBlock>assignedblocks, long taskid, string taskname) { 
            AssignedBlocks = assignedblocks;
            TaskId = taskid;
        }
        public List<DateTimeBlock> AssignedBlocks { get; set; }
        public long TaskId { get; set; }

        public AssignedTask()
        {
            AssignedBlocks = new List<DateTimeBlock>();
        }
    }
}

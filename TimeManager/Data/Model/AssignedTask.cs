using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TimeManager.Data.Model
{
    public class AssignedTask
    {
        public List<DateTimeBlock> AssignedBlocks { get; set; }
        public long TaskId { get; set; }

        public AssignedTask()
        {
            AssignedBlocks = new List<DateTimeBlock>();
        }
    }
}

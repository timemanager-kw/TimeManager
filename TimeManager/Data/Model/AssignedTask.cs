using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TimeManager.Data.Model
{
    class AssignedTask
    {
        public List<DateTimeBlock> AssignedBlocks { get; set; }
        public long TaskId { get; set; }
    }
}

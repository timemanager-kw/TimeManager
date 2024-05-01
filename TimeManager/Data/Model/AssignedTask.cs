using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TimeManager.Data.Model
{
    class AssignedTask
    {
        public DateTimeBlock[] DateTimeBlocks { get; set; }
        public Task Task { get; set; }
    }
}

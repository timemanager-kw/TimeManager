using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TimeManager.Data.Model
{
    class SingleSchedule : Schedule 
    {
        public DateTimeBlock DateTimeBlock { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace TimeManager.Data.Model
{
    struct DateTimeBlock
    {
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

        public TimeSpan Duration
        {
            get
            {
                return EndDate - StartDate;
            }
        }

        // TODO: static 말고 일반 메서드로 구현
        public static IEnumerable<DateTimeBlock> Difference(IEnumerable<DateTimeBlock> minuend, IEnumerable<DateTimeBlock> subtrahend)
        {
            throw new NotImplementedException();
        }
    }
}

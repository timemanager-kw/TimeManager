using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace TimeManager.Data.Model
{
    public struct DateTimeBlock
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

        public DateTimeBlock(DateTime startDate, DateTime endDate)
        {
            StartDate = startDate;
            EndDate = endDate;
        }

        public static IEnumerable<DateTimeBlock> Difference(IEnumerable<DateTimeBlock> minuend, IEnumerable<DateTimeBlock> subtrahend)
        {

            throw new NotImplementedException();
        }
    }
}

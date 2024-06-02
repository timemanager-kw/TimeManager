using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TimeManager.Data.Model
{
    public struct longTermProperties
    {
        public longTermProperties(DayOfWeek d, TimeSpan t){ 
            dayOfWeek = d;
            time = t;
        }
        /// <summary>
        /// Type이 LongTerm일 때에만 존재합니다.
        /// </summary>
        public DayOfWeek dayOfWeek;
        /// <summary>
        /// Type이 LongTerm일 때에만 존재합니다.
        /// </summary>
        public TimeSpan time;
    }
}

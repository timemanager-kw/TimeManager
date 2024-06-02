using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TimeManager.Data.Model
{
    public struct longTermProperties
    {
        /// <summary>
        /// Type이 LongTerm일 때에만 존재합니다.
        /// </summary>
        public List<WeeklyDateTimeBlock> WeeklyTimesWanted { get; set; }
        /// <summary>
        /// Type이 LongTerm일 때에만 존재합니다.
        /// </summary>
        public int? NDaysOfWeekWanted { get; set; }
    }
}

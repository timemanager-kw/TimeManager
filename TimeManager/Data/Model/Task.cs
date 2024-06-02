using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TimeManager.Data.Model
{
    public enum ETaskType
    {
        /// <summary>
        /// 마감기한이 있는 짧은 기간의 Task입니다.
        /// </summary>
        ShortTerm,

        /// <summary>
        /// 매주 정기적으로 반복되길 희망하는 장기적인 Task입니다.
        /// </summary>
        LongTerm
    }

    public class Task
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public ETaskType Type { get; set; }

        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }

        /// <summary>
        /// Type이 ShortTerm일 때에만 존재합니다.
        /// </summary>
        public TimeSpan? Duration { get; set; }

        /// <summary>
        /// Type이 ShortTerm일 때에만 존재합니다.
        /// </summary>
        public int? FocusDays { get; set; }

        public List<longTermProperties> WeeklyTimesWanted { get; set; }
    }
}

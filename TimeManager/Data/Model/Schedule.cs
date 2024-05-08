using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TimeManager.Data.Model
{
    enum EScheduleType
    {
        Singular,
        Regular
    }

    class Schedule
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public EScheduleType Type { get; set; }

        /// <summary>
        /// Type이 Singular인 경우에는 실제 Schedule이 수행되는 시간을 의미하며,
        /// Type이 Regular인 경우에는 반복이 일어나는 전체 기간을 의미합니다.
        /// </summary>
        public DateTimeBlock TimeBlock { get; set; }

        /// <summary>
        /// 반복 요일 및 시간들을 나타냅니다.
        /// Type이 Regular인 경우에만 사용됩니다.
        /// </summary>
        public List<WeeklyDateTimeBlock> RegularTimeBlocks { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TimeManager.Data.Model;
using TimeManager.Data.Repository;

namespace TimeManager.Data.Manager
{
    class TimeTableManager : ITimeTableManager
    {
        private readonly ITimeTableRepository _timeTableRepository;
        private TimeTable _timeTable;

        public TimeTableManager(ITimeTableRepository timeTableRepository)
        {
            _timeTableRepository = timeTableRepository;
            _timeTable = _timeTableRepository.Load();
        }

        public void Clear()
        {
            _timeTableRepository.Clear();
            _timeTable = _timeTableRepository.Load();
        }

        public TimeTable Get()
        {
            return _timeTable;
        }

        public void Save(TimeTable timeTable)
        {
            _timeTableRepository.Update(timeTable);
            _timeTable = timeTable;
        }
    }
}

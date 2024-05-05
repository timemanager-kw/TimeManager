﻿using System;
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
        private readonly TimeTable _timeTable;

        public TimeTableManager(ITimeTableRepository timeTableRepository)
        {
            _timeTableRepository = timeTableRepository;
            _timeTable = _timeTableRepository.Load();
        }

        public void Add(TimeTable timeTable)
        {
            throw new NotImplementedException();
        }

        public void Delete(TimeTable timeTable)
        {
            throw new NotImplementedException();
        }

        public TimeTable Get()
        {
            throw new NotImplementedException();
        }

        public void Update(TimeTable timeTable)
        {
            throw new NotImplementedException();
        }
    }
}

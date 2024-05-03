using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TimeManager.Data.Model;
using TimeManager.Data.Repository;

namespace TimeManager.Data.Manager
{
    class ScheduleManager : IScheduleManager
    {
        private readonly IScheduleRepository _scheduleRepository;
        private List<Schedule> schedules;

        public ScheduleManager(IScheduleRepository scheduleRepository)
        {
            _scheduleRepository = scheduleRepository;
            schedules = (List<Schedule>) scheduleRepository.LoadAll();
        }

        public void Add(Schedule schedule)
        {
            throw new NotImplementedException();
        }

        public void Delete(Schedule schedule)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Schedule> GetAll()
        {
            return schedules;
        }

        public void Update(Schedule schedule)
        {
            throw new NotImplementedException();
        }
    }
}

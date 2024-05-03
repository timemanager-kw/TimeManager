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
        private readonly List<Schedule> schedules;

        public ScheduleManager(IScheduleRepository scheduleRepository)
        {
            _scheduleRepository = scheduleRepository;
            schedules = (List<Schedule>) _scheduleRepository.LoadAll();
        }

        public void Add(Schedule schedule)
        {
            // TODO: ID 등록
            throw new NotImplementedException("TODO: ID 등록");

            _scheduleRepository.Add(schedule);
        }

        public void Delete(Schedule schedule)
        {
            _scheduleRepository.Delete(schedule);
        }

        public IEnumerable<Schedule> GetAll()
        {
            return schedules;
        }

        public void Update(Schedule schedule)
        {
            _scheduleRepository.Update(schedule);
        }
    }
}

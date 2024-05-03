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
        private readonly List<Schedule> _schedules;

        public ScheduleManager(IScheduleRepository scheduleRepository)
        {
            _scheduleRepository = scheduleRepository;
            _schedules = (List<Schedule>) _scheduleRepository.LoadAll();
        }

        public void Add(Schedule schedule)
        {
            // TODO: ID 등록
            throw new NotImplementedException("TODO: ID 등록");

            _scheduleRepository.Add(schedule);
            _schedules.Add(schedule);
        }

        public void Delete(Schedule schedule)
        {
            _scheduleRepository.Delete(schedule);
            _schedules.Remove(schedule);
        }

        public IEnumerable<Schedule> GetAll()
        {
            return _schedules;
        }

        public void Update(Schedule schedule)
        {
            int idx = _schedules.FindIndex(s => s.Id == schedule.Id);
            if (idx == -1)
                throw new ArgumentException("존재하지 않는 스케줄입니다.");

            _scheduleRepository.Update(schedule);
            _schedules[idx] = schedule;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TimeManager.Data.Model;

namespace TimeManager.Data.Repository
{
    interface IScheduleRepository
    {
        void Add(Schedule schedule);
        void Update(Schedule schedule);
        void Delete(Schedule schedule);
        IEnumerable<Schedule> LoadAll();
    }
}

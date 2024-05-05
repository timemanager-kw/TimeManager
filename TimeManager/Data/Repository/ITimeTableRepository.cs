using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TimeManager.Data.Model;

namespace TimeManager.Data.Repository
{
    interface ITimeTableRepository
    {
        void Save(TimeTable timeTable);
        void Clear(TimeTable timeTable);
        TimeTable Load();
    }
}

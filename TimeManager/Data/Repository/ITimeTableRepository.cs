using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TimeManager.Data.Model;

namespace TimeManager.Data.Repository
{
    public interface ITimeTableRepository
    {
        void Update(TimeTable timeTable);
        void Clear();
        TimeTable Load();
    }
}

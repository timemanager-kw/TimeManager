using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TimeManager.Data.Model;

namespace TimeManager.Data.Manager
{
    public interface ITimeTableManager
    {
        TimeTable Get();
        void Save(TimeTable timeTable);
        void Clear();
    }
}

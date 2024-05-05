using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TimeManager.Data.Model;

namespace TimeManager.Data.Manager
{
    interface ITimeTableManager
    {
        TimeTable Get();
        void Save(TimeTable timeTable);
        void Clear(TimeTable timeTable);
    }
}

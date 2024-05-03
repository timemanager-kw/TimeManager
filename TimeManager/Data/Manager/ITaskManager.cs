using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TimeManager.Data.Model;

namespace TimeManager.Data.Manager
{
    interface ITaskManager
    {
        void Add(Task task);
        void Update(Task task);
        void Delete(Task task);
        IEnumerable<Task> GetAll();
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TimeManager.Data.Repository
{
    interface ITaskRepository
    {
        void Add(Task task);
        void Update(Task task);
        void Delete(Task task);
        IEnumerable<Task> LoadAll();
    }
}

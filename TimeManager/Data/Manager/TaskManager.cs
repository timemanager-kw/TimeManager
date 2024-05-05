using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TimeManager.Data.Model;
using TimeManager.Data.Repository;

namespace TimeManager.Data.Manager
{
    class TaskManager : ITaskManager
    {
        private readonly ITaskRepository _taskRepository;
        private readonly List<Task> _tasks;

        public TaskManager(ITaskRepository taskRepository, List<Task> tasks)
        {
            _taskRepository = taskRepository;
            _tasks = tasks;
        }

        public void Add(Task task)
        {
            throw new NotImplementedException();
        }

        public void Delete(Task task)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Task> GetAll()
        {
            throw new NotImplementedException();
        }

        public void Update(Task task)
        {
            throw new NotImplementedException();
        }
    }
}

﻿using System;
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

        public TaskManager(ITaskRepository taskRepository)
        {
            _taskRepository = taskRepository;
            _tasks = (List<Task>) _taskRepository.LoadAll();
        }

        public void Add(Task task)
        {
            _taskRepository.Add(task);
            _tasks.Add(task);
        }

        public void Delete(Task task)
        {
            _taskRepository.Delete(task);
            _tasks.Remove(task);
        }

        public IEnumerable<Task> GetAll()
        {
            return _tasks;
        }

        public void Update(Task task)
        {
            throw new NotImplementedException();
        }
    }
}

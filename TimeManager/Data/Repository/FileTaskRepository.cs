﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TimeManager.Data.Model;

namespace TimeManager.Data.Repository
{
    internal class FileTaskRepository:  ITaskRepository
    {
        private readonly string filePath;
        FileTaskRepository(string filePath)
        {
            this.filePath = filePath;
            if (!File.Exists(filePath))
            {
                using (StreamWriter writer = new StreamWriter(filePath))
                {
                    writer.WriteLine("파일을 찾을 수 없습니다.");
                }
            }
        }
        void Add(Model.Task task)
        {
            int nextId;
            using (StreamReader reader = new StreamReader(filePath))
            {
                nextId = int.Parse(reader.ReadLine());
            }
            task.Id = nextId;
            using (StreamWriter writer = new StreamWriter(filePath))
            {
                writer.WriteLine($"{task.Id}, {task.Name}, {task.Description}, {task.Type}, {task.StartDate}, {task.EndDate},{task.Duration}, {task.FocusDays}, {task.WeeklyTimesWanted}, {task.NDaysOfWeekWanted}");
            }
            using (StreamWriter writer = new StreamWriter(filePath))
            {
                writer.WriteLine(++nextId);
            }
        }
        void Update(Model.Task task)
        {

        }
        void Delete(Model.Task task)
        {

        }
        IEnumerable<Model.Task> LoadAll() { 

        }
    }
}

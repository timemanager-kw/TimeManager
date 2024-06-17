using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using TimeManager.Data.Model;

namespace TimeManager.Data.Repository
{
    internal class FileTaskRepository:  ITaskRepository
    {
        private readonly string filePath;
        public FileTaskRepository(string filePath)
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
        public void Add(Task task)
        {
            int nextId;
            using (StreamReader reader = new StreamReader(filePath))
            {
                nextId = int.Parse(reader.ReadLine());
            }
            task.Id = nextId;
            using (StreamWriter writer = new StreamWriter(filePath))
            {
                writer.WriteLine($"{task.Id}, {task.Name}, {task.Description}, {(int)task.Type}, {task.StartDate}, {task.EndDate},{task.Duration}, {task.FocusDays}, {SerializeWeeklyTimes(task.WeeklyTimesWanted)}");
            }
            using (StreamWriter writer = new StreamWriter(filePath))
            {
                writer.WriteLine(++nextId);
            }
        }
        private string SerializeWeeklyTimes(List<longTermProperties> weeklyTimes)
        {
            List<string> serializedTimes = new List<string>();
            foreach(var weeklyTime in weeklyTimes)
            {
                string serializedTime = $"{weeklyTime.dayOfWeek}|{weeklyTime.time}";
                serializedTimes.Add(serializedTime);
            }
            return string.Join(";", serializedTimes);
        }
        public void Update(Task task)
        {
            List<string> lines = File.ReadAllLines(filePath).ToList();
            for (int i = 1; i < lines.Count; i++)
            {
                string[] parts = lines[i].Split(',');
                if (int.Parse(parts[0]) == task.Id)
                {
                    lines[i] = $"{task.Id}, {task.Name}, {task.Description}, {task.Type}, {task.StartDate}, {task.EndDate},{task.Duration}, {task.FocusDays}, {SerializeWeeklyTimes(task.WeeklyTimesWanted)}";
                    break;
                }
            }
            File.WriteAllLines(filePath, lines);
        }
        public void Delete(Task task)
        {
            List<string> lines = File.ReadAllLines(filePath).ToList();
            for (int i = 1; i < lines.Count; i++)
            {
                string[] parts = lines[i].Split(',');
                if (int.Parse(parts[0]) == task.Id)
                {
                    lines.RemoveAt(i);
                    break;
                }
            }
            File.WriteAllLines(filePath, lines);
        }
        public IEnumerable<Task> LoadAll() { 
            List<Task> tasks = new List<Task>();
            List<string> lines = File.ReadAllLines(filePath).ToList();
            for(int i = 1; i < lines.Count; i++)
            {
                string[] parts = lines[i].Split(',');
                Task task = new Task
                {
                    Id = long.Parse(parts[0]),
                    Name = parts[1],
                    Description = parts[2],
                    Type = (ETaskType)int.Parse(parts[3]),
                    StartDate = DateTime.Parse(parts[4]),
                    EndDate = DateTime.Parse(parts[5]),
                    Duration = TimeSpan.Parse(parts[6]),
                    FocusDays = int.Parse(parts[7]),
                    WeeklyTimesWanted = new List<longTermProperties>(),
                };
                string[] weeklyTimesParts = parts[8].Split(';');
                foreach(string weeklyTimesPart in weeklyTimesParts)
                {
                    string[] weeklyTimeSubParts = weeklyTimesPart.Split('|');
                    longTermProperties week = new longTermProperties();
                    DayOfWeek dayOfWeek;
                    Enum.TryParse<DayOfWeek>(weeklyTimeSubParts[0], out dayOfWeek);
                    week.dayOfWeek = dayOfWeek;
                    week.time = TimeSpan.Parse(weeklyTimesParts[1]);
                }
            tasks.Add(task);
            }
            return tasks;
        }
    }
}

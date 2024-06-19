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
        long nextId;
        private string filePath = Path.Combine(Path.GetDirectoryName(System.Diagnostics.Process.GetCurrentProcess().MainModule.FileName), "TaskPath");
        public FileTaskRepository()
        {
            if (!File.Exists(filePath))
            {
                using (StreamWriter writer = new StreamWriter(filePath))
                {
                }
            }
        }
        public void Add(Task task)
        {
            using (StreamReader reader = new StreamReader(filePath))
            {
                string line;
                if ((line = reader.ReadLine()) == null)
                {
                    nextId = 0;
                }
                else
                {
                    while (!reader.EndOfStream)
                    {
                        line = reader.ReadLine();
                    }
                    nextId = long.Parse(line.Split(',')[0]);
                }
            }
            ++nextId;
            task.Id = nextId;
            using (StreamWriter writer = new StreamWriter(filePath, true))
            {
                writer.WriteLine($"{task.Id},{task.Name},{task.Description},{(int)task.Type},{task.StartDate},{task.EndDate},{task.Duration},{task.FocusDays},{SerializeWeeklyTimes(task.WeeklyTimesWanted)}");
            }
        }
        private string SerializeWeeklyTimes(List<longTermProperties> weeklyTimes)
        {
            List<string> serializedTimes = new List<string>();
            if (weeklyTimes != null)
            {
                foreach (var weeklyTime in weeklyTimes)
                {
                    string serializedTime = $"{weeklyTime.dayOfWeek}|{weeklyTime.time}";
                    serializedTimes.Add(serializedTime);
                }
            }
            return string.Join(";", serializedTimes);
        }
        public void Update(Task task)
        {
            List<string> lines = File.ReadAllLines(filePath).ToList();
            for (int i = 0; i < lines.Count; i++)
            {
                string[] parts = lines[i].Split(',');
                if (int.Parse(parts[0]) == task.Id)
                {
                    lines[i] = $"{task.Id},{task.Name},{task.Description},{(int)task.Type},{task.StartDate},{task.EndDate},{task.Duration},{task.FocusDays},{SerializeWeeklyTimes(task.WeeklyTimesWanted)}";
                    break;
                }
            }
            File.WriteAllLines(filePath, lines);
        }
        public void Delete(Task task)
        {
            List<string> lines = File.ReadAllLines(filePath).ToList();
            for (int i = 0; i < lines.Count; i++)
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
            for(int i = 0; i < lines.Count; i++)
            {
                string[] parts = lines[i].Split(',');
                Task task = new Task
                {
                    Id = long.Parse(parts[0]),
                    Name = parts[1],
                    Description = parts[2],
                    Type = (ETaskType)Enum.Parse(typeof(EScheduleType),parts[3]),
                    StartDate = DateTime.Parse(parts[4]),
                    EndDate = (ETaskType)Enum.Parse(typeof(EScheduleType), parts[3]) == ETaskType.ShortTerm ? DateTime.Parse(parts[5]) : new DateTime(),
                    
                    Duration = (ETaskType)Enum.Parse(typeof(EScheduleType), parts[3]) == ETaskType.ShortTerm ? TimeSpan.Parse(parts[6]): new TimeSpan(),
                    FocusDays = (ETaskType)Enum.Parse(typeof(EScheduleType), parts[3]) == ETaskType.ShortTerm ? int.Parse(parts[7]): 0,
                    
                    WeeklyTimesWanted = new List<longTermProperties>(),
                };
                if (task.Type == ETaskType.LongTerm)
                {
                    string[] weeklyTimesParts = parts[8].Split(';');
                    foreach (string weeklyTimesPart in weeklyTimesParts)
                    {
                        string[] weeklyTimeSubParts = weeklyTimesPart.Split('|');
                        longTermProperties week = new longTermProperties();
                        DayOfWeek dayOfWeek;
                        Enum.TryParse<DayOfWeek>(weeklyTimeSubParts[0], out dayOfWeek);
                        week.dayOfWeek = dayOfWeek;
                        week.time = TimeSpan.Parse(weeklyTimeSubParts[1]);
                        task.WeeklyTimesWanted.Add(week);
                    }
                }
            tasks.Add(task);
            }
            return tasks;
        }
    }
}

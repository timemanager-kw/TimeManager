using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TimeManager.Data.Model;

namespace TimeManager.Data.Repository
{
    public class FileScheduleRepository : IScheduleRepository
    {
        long nextId;
        private string filePath = Path.Combine(Path.GetDirectoryName(System.Diagnostics.Process.GetCurrentProcess().MainModule.FileName), "SchedulePath");
        public FileScheduleRepository()
        {
            if (!File.Exists(filePath))
            {
                using (StreamWriter writer = new StreamWriter(filePath))
                {
                }
            }
        }
        public void Add(Schedule schedule)
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
            schedule.Id = nextId;
            using (StreamWriter writer = new StreamWriter(filePath,true))
            {
                writer.WriteLine($"{schedule.Id},{schedule.Name},{schedule.Description},{schedule.Type},{schedule.TimeBlock.StartDate},{schedule.TimeBlock.EndDate},{SerializeWeeklyTimes(schedule.RegularTimeBlocks)}");
                
            }
        }
        
        private string SerializeWeeklyTimes(List<WeeklyDateTimeBlock> regularTimeBlocks)
        {
            List<string> serializedTimes = new List<string>();
            if (regularTimeBlocks != null)
            {
                foreach (var time in regularTimeBlocks)
                {
                    string serializedTime = $"{time.DayOfWeek}|{time.StartTime}|{time.EndTime}";
                    serializedTimes.Add(serializedTime);
                }
            }
            return string.Join(";", serializedTimes);
        }
        public void Update(Schedule schedule)
        {
            List<string> lines = File.ReadAllLines(filePath).ToList();
            for (int i = 0; i < lines.Count; i++)
            {
                string[] parts = lines[i].Split(',');
                if (long.Parse(parts[0]) == schedule.Id)
                {
                    lines[i] = $"{schedule.Id},{schedule.Name},{schedule.Description},{schedule.Type},{schedule.TimeBlock.StartDate},{schedule.TimeBlock.EndDate},{SerializeWeeklyTimes(schedule.RegularTimeBlocks)}";
                    break;
                }
            }
            File.WriteAllLines(filePath, lines);
        }
        public void Delete(Schedule schedule)
        {
            List<string> lines = File.ReadAllLines(filePath).ToList();
            for (int i = 0; i < lines.Count; i++)
            {
                string[] parts = lines[i].Split(',');
                if (long.Parse(parts[0]) == schedule.Id)
                {
                    lines.RemoveAt(i);
                    break;
                }
            }
            File.WriteAllLines(filePath, lines);
        }
        public IEnumerable<Schedule> LoadAll()
        {
            List<Schedule> schedules = new List<Schedule>();
            List<string> lines = File.ReadAllLines(filePath).ToList();
            for (int i = 0; i < lines.Count; i++)
            {
                string[] parts = lines[i].Split(',');
                Schedule schedule = new Schedule
                {
                    Id = long.Parse(parts[0]),
                    Name = parts[1],
                    Description = parts[2],
                    Type = (EScheduleType)Enum.Parse(typeof(EScheduleType), parts[3]),
                    TimeBlock = new DateTimeBlock
                    {
                        StartDate = DateTime.Parse(parts[4]),
                        EndDate = DateTime.Parse(parts[5]),
                    },
                    RegularTimeBlocks = new List<WeeklyDateTimeBlock>(),
                };
                if (schedule.Type != EScheduleType.Singular)
                {
                    string[] weeklyTimesParts = parts[6].Split(';');
                    foreach (string weeklyTimesPart in weeklyTimesParts)
                    {
                        string[] weeklyTimeSubParts = weeklyTimesPart.Split('|');
                        WeeklyDateTimeBlock week = new WeeklyDateTimeBlock();
                        DayOfWeek dayOfWeek;
                        Enum.TryParse<DayOfWeek>(weeklyTimeSubParts[0], out dayOfWeek);
                        week.DayOfWeek = dayOfWeek;
                        week.StartTime = DateTime.Parse(weeklyTimeSubParts[1]);
                        week.EndTime = DateTime.Parse(weeklyTimeSubParts[2]);
                        schedule.RegularTimeBlocks.Add(week);
                    }
                }
                schedules.Add(schedule);
            }
            return schedules;
        }
    }
}
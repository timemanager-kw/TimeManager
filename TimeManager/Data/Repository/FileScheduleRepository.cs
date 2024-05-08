using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TimeManager.Data.Model;

namespace TimeManager.Data.Repository
{
    internal class FileScheduleRepository : IScheduleRepository
    {
        private readonly string filePath;
        public FileScheduleRepository(string filePath)
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
        void Add(Schedule schedule) {
            int nextId;
            using (StreamReader reader = new StreamReader(filePath))
            {
                nextId = int.Parse(reader.ReadLine());
            }
            schedule.Id = nextId;
            using(StreamWriter writer = new StreamWriter(filePath))
            {
                writer.WriteLine($"{schedule.Id}, {schedule.Name}, {schedule.Type}, {schedule.TimeBlock.StartDate}, {schedule.TimeBlock.EndDate}, {schedule.Description}");
            }
            using(StreamWriter writer = new StreamWriter(filePath))
            {
                writer.WriteLine(++nextId);
            }
        }
        void Update(Schedule schedule) {
            List<string> lines = File.ReadAllLines(filePath).ToList();
            for(int i = 1; i < lines.Count; i++)
            {
                string[] parts = lines[i].Split(',');
                if (int.Parse(parts[0]) == schedule.Id)
                {
                    lines[i] = $"{schedule.Id}, {schedule.Name}, {schedule.Type}, {schedule.TimeBlock.StartDate}, {schedule.TimeBlock.EndDate}, {schedule.Description}";
                    break;
                }
            }
            File.WriteAllLines(filePath, lines);
        }
        void Delete(Schedule schedule);
        IEnumerable<Schedule> LoadAll();
    }
}

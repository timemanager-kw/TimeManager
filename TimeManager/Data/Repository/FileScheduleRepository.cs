﻿using System;
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
        public void Add(Schedule schedule)
        {
            long nextId;
            using (StreamReader reader = new StreamReader(filePath))
            {
                nextId = long.Parse(reader.ReadLine());
            }
            schedule.Id = nextId;
            using (StreamWriter writer = new StreamWriter(filePath))
            {
                writer.WriteLine($"{schedule.Id}, {schedule.Name}, {schedule.Description}, {schedule.Type}, {schedule.TimeBlock.StartDate}, {schedule.TimeBlock.EndDate}, {SerializeWeeklyTimes(schedule.RegularTimeBlocks)}");
            }
            using (StreamWriter writer = new StreamWriter(filePath))
            {
                writer.WriteLine(++nextId);
            }
        }
        
        private string SerializeWeeklyTimes(List<WeeklyDateTimeBlock> regularTimeBlocks)
        {
            List<string> serializedTimes = new List<string>();
            foreach(var time in regularTimeBlocks)
            {
                string serializedTime = $"{time.DayOfWeek}|{time.StartTime}|{time.EndTime}";
                serializedTimes.Add(serializedTime);
            }
            return string.Join(";", serializedTimes);
        }
        public void Update(Schedule schedule)
        {
            List<string> lines = File.ReadAllLines(filePath).ToList();
            for (int i = 1; i < lines.Count; i++)
            {
                string[] parts = lines[i].Split(',');
                if (int.Parse(parts[0]) == schedule.Id)
                {
                    lines[i] = $"{schedule.Id}, {schedule.Name}, {schedule.Description}, {schedule.Type}, {schedule.TimeBlock.StartDate}, {schedule.TimeBlock.EndDate}, {schedule.RegularTimeBlocks}";
                    break;
                }
            }
            File.WriteAllLines(filePath, lines);
        }
        public void Delete(Schedule schedule)
        {
            List<string> lines = File.ReadAllLines(filePath).ToList();
            for (int i = 1; i < lines.Count; i++)
            {
                string[] parts = lines[i].Split(',');
                if (int.Parse(parts[0]) == schedule.Id)
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
            for (int i = 1; i < lines.Count; i++)
            {
                string[] parts = lines[i].Split(',');
                Schedule schedule = new Schedule
                {
                    Id = long.Parse(parts[0]),
                    Name = parts[1],
                    Description = parts[2],
                    Type = (EScheduleType)int.Parse(parts[3]),
                    TimeBlock = new DateTimeBlock
                    {
                        StartDate = DateTime.Parse(parts[4]),
                        EndDate = DateTime.Parse(parts[5]),
                    },
                   RegularTimeBlocks = new List<WeeklyDateTimeBlock>(),
                };
                string[] weeklyTimesParts = parts[8].Split(';');
                foreach(string weeklyTimesPart in weeklyTimesParts)
                {
                    string[] weeklyTimeSubParts = weeklyTimesPart.Split('|');
                    WeeklyDateTimeBlock week = new WeeklyDateTimeBlock();
                    DayOfWeek dayOfWeek;
                    Enum.TryParse<DayOfWeek>(weeklyTimesParts[0], out dayOfWeek);
                    week.DayOfWeek = dayOfWeek;
                    week.StartTime = DateTime.Parse(weeklyTimesParts[1]);
                    week.EndTime = DateTime.Parse(weeklyTimesParts[2]);
                }
                schedules.Add(schedule);
            }
            return schedules;
        }
    }
}
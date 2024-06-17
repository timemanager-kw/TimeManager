using Microsoft.SqlServer.Server;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using TimeManager.Data.Model;

namespace TimeManager.Data.Repository
{
    internal class FileTimeTableRepository: ITimeTableRepository
    {
        private string filePath = Path.Combine(Path.GetDirectoryName(System.Diagnostics.Process.GetCurrentProcess().MainModule.FileName), "TimeTablePath");
        public FileTimeTableRepository(string filePath)
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

        public void Update(TimeTable timeTable)
        {
            using(StreamWriter writer = new StreamWriter(filePath))
            {
                foreach(var workTime in timeTable.WorkTimes)
                {
                    writer.WriteLine($"{"WorkTimes:"}, {workTime.StartDate}, {workTime.EndDate}, {workTime.Duration}");
                }
                foreach(var schedule in timeTable.AssignedSchedules)
                {
                    string assignedBlocks = string.Join(",", schedule.AssignedBlocks.Select(block => $"{block.StartDate}, {block.EndDate}, {block.Duration}"));
                    writer.WriteLine($"{"AssignedSchedules:"}, {schedule.ScheduleId}, {assignedBlocks}");
                }
                foreach(var task in timeTable.AssignedTasks)
                {
                    string assignedBlocks = string.Join(",",task.AssignedBlocks.Select(block =>$"{block.StartDate}, {block.EndDate}, {block.Duration}"));
                    writer.WriteLine($"{"AssignedTasks"}, {task.TaskId}, {assignedBlocks}");
                }
            }
        }
        public void Clear()
        {
            File.WriteAllText(filePath, string.Empty);
        }
        public TimeTable Load()
        {
            List<DateTimeBlock> blocks = new List<DateTimeBlock>();
            List<AssignedSchedule> scheduleBlock = new List<AssignedSchedule>();
            List<AssignedTask> taskBlock = new List<AssignedTask>();
            using (StreamReader reader = new StreamReader(filePath))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    if (line.Contains("WorkTimes:"))
                    {
                        string[] parts = line.Split(',');
                        DateTime startDate = DateTime.Parse(parts[1]);
                        DateTime endDate = DateTime.Parse(parts[2]);
                        blocks.Add(new DateTimeBlock(startDate, endDate));
                        
                    }
                    else if (line.Contains("AssignedSchedule:"))
                    {
                        string[] parts = line.Split(',');
                        long scheduleId = long.Parse(parts[1]);
                        string scheduleName = parts[2];
                        string[] scheduleBlocks = parts[3].Split(',');
                        List<DateTimeBlock> assignedBlocks = scheduleBlocks.Select(block =>
                        {
                            string[] blockParts = block.Split(',');
                            DateTime startDate = DateTime.Parse(blockParts[0]);
                            DateTime endDate = DateTime.Parse(blockParts[1]);
                            return new DateTimeBlock(startDate, endDate);
                        }).ToList();
                        scheduleBlock.Add(new AssignedSchedule(assignedBlocks, scheduleId));
                    
                    }
                    else if (line.Contains("AssignedTasks:"))
                    {
                        
                        string[] parts = line.Split(',');
                        long taskId = long.Parse(parts[1]);
                        string taskName = parts[2];
                        string[] taskBlocks = parts[3].Split(',');
                        List<DateTimeBlock> assignedBlocks = taskBlocks.Select(block =>
                        {
                            string[] blockParts = block.Split(',');
                            DateTime startDate = DateTime.Parse(blockParts[0]);
                            DateTime endDate = DateTime.Parse(blockParts[1]);
                            return new DateTimeBlock(startDate, endDate);
                        }).ToList();
                        taskBlock.Add(new AssignedTask(assignedBlocks, taskId));
                        
                    }
                }
            }
            TimeTable timeTable = new TimeTable(blocks, scheduleBlock, taskBlock);
            return timeTable;
        }
    }
}

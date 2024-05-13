using Microsoft.SqlServer.Server;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TimeManager.Data.Model;

namespace TimeManager.Data.Repository
{
    internal class FileTimeTableRepository: ITimeTableRepository
    {
        private readonly string filePath;
        FileTimeTableRepository(string filePath)
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
                    writer.WriteLine($"{workTime.StartDate}, {workTime.EndDate}, {workTime.Duration}");
                }
                foreach(var schedule in timeTable.AssignedSchedules)
                {
                    string assignedBlocks = string.Join(",", schedule.AssignedBlocks.Select(block => $"{block.StartDate}, {block.EndDate}, {block.Duration}"));
                    writer.WriteLine($"{schedule.ScheduleId}, {schedule.ScheduleName}, {assignedBlocks}");
                }
                foreach(var task in timeTable.AssignedTasks)
                {
                    string assignedBlocks = string.Join(",",task.AssignedBlocks.Select(block =>$"{block.StartDate}, {block.EndDate}, {block.Duration}"));
                    writer.WriteLine($"{task.TaskId}, {task.TaskName}, {assignedBlocks}");
                }
            }
        }
        public void Clear()
        {
        }
        public TimeTable Load()
        {
            
        }
    }
}

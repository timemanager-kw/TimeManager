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
        //TimeTable의 WorkTimes, AssignedSchedules, AssignedTasks 속성을 저장/로드
        public void Update(TimeTable timeTable)
        {
            List<string> lines = File.ReadAllLines(filePath).ToList();

        }
        public void Clear()
        {

        }
        public TimeTable Load()
        {
            TimeTable timeTable = new TimeTable();
            return timeTable;
        }
    }
}

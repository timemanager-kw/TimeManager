using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using TimeManager.Data.Model;
using TimeManager.Scheduler;
using TimeManager.Extensions;

namespace TimeManagerUnitTests.Scheduler
{
    [TestClass]
    public class ThunderSchedulerStrategyUnitTests
    {
        private ISchedulerStrategy strategy = new ThunderSchedulerStrategy();

        /// <summary>
        /// 가용 시간 여유 있고, ShortTerm Type Task 3개만 있는 경우
        /// 모두 배치하고 마감일 전 혹은 당일에 배치되어 있어야 함
        /// </summary>
        [TestMethod]
        public void 가용시간여유_ShortTerm_Task_3개_모두_마감일_전_혹은_당일에_배치해야_한다()
        {
            /* given */
            // WorkTime
            List<DateTimeBlock> workTimes = new List<DateTimeBlock>();
            for (int i = 0; i < 7; i++)
                workTimes.Add(new DateTimeBlock(DateTime.Today.AddDays(0).AddHours(9), DateTime.Today.AddDays(0).AddHours(18)));

            // WorkTime 및 Schedule이 지정된 timeTable
            TimeTable timeTable = new TimeTable(
                workTimes,
                new List<AssignedSchedule>()
                {
                    new AssignedSchedule(
                        new List<DateTimeBlock>()
                        {
                            new DateTimeBlock(DateTime.Today.AddDays(1).AddHours(12), DateTime.Today.AddDays(1).AddHours(16))
                        },
                        0
                    )
                },
                new List<AssignedTask>()
            );
            
            // 배치할 tasks
            List<Task> tasks = new List<Task>();
            for (int i = 0; i < 3; i++)
            {
                tasks.Add(new Task()
                {
                    Id = i,
                    Name = $"Task {i}",
                    Description = $"Task {i}: {3+i}일 뒤 마감, 3일 총 10시간 집중",
                    Type = ETaskType.ShortTerm,
                    StartDate = DateTime.Today,
                    EndDate = DateTime.Today.AddDays(3 + i),
                    Duration = new TimeSpan(10, 0, 0),
                    FocusDays = 3
                });

                Trace.WriteLine(tasks[i].Description);
            }

            /* when */
            strategy.Schedule(timeTable, tasks);

            /* then */
            // 모두 배치되어야 함
            Assert.AreEqual(3, timeTable.AssignedTasks.Count);

            // 모두 마감일 전 혹은 당일에 배치되어 있어야 함
            foreach (var assignedTask in timeTable.AssignedTasks)
            {
                assignedTask.AssignedBlocks.ForEach(block =>
                {
                    Trace.WriteLine($"Task {assignedTask.TaskId}: {block.StartDate} ~ {block.EndDate}");
                    Assert.IsTrue(block.EndDate.StartOfDay() <= tasks.Find(t => t.Id == assignedTask.TaskId).EndDate?.StartOfDay() );
                });
            }
        }
    }
}

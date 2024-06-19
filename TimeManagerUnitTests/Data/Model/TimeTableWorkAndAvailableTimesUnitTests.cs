using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TimeManager.Data.Model;

namespace TimeManagerUnitTests.Model
{
    [TestClass]
    public class TimeTableWorkAndAvailableTimesUnitTests
    {
        private TimeTable timeTable = new TimeTable();

        [TestMethod]
        public void GetAvailableTimesInBlock에서_하루에_대한_부분_가용시간을_가져올_수_있다()
        {
            timeTable.SetWorkTimes(new List<DateTimeBlock>() {
                new DateTimeBlock(DateTime.Today.AddHours(9), DateTime.Today.AddHours(18)),

            });

            timeTable.AssignSchedule(1, new List<DateTimeBlock>() {
                new DateTimeBlock(DateTime.Today.AddHours(12), DateTime.Today.AddHours(16))
            });

            List<DateTimeBlock> availableTimes = timeTable.GetAvailableTimesInBlock(new DateTimeBlock(
                DateTime.Today.AddHours(8),
                DateTime.Today.AddHours(17)
            ));

            Trace.WriteLine($"Available Blocks: {availableTimes.Count}");
            Assert.IsTrue(availableTimes.Count == 2);

            Assert.IsTrue(availableTimes[0].StartDate.Hour == 9 && availableTimes[0].EndDate.Hour == 12);
            Assert.IsTrue(availableTimes[1].StartDate.Hour == 16 && availableTimes[1].EndDate.Hour == 18);

            foreach (var availableTime in availableTimes)
            {
                Trace.WriteLine($"Available Time: {availableTime.StartDate} ~ {availableTime.EndDate}");
                Assert.IsTrue(availableTime.StartDate.Hour >= 9 && availableTime.EndDate.Hour <= 12);
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TimeManager.Data.Model
{
    interface ITimeTable
    {
        void SetWorkTimes(List<DateTimeBlock> workTimes);
        List<DateTimeBlock> GetWorkTimes();

        List<DateTimeBlock> GetAvailableTimes(DateTime week);

        void AssignSchedule(AssignedSchedule assignedSchedule);
        void UnassignSchedule(AssignedSchedule assignedSchedule);
        List<AssignedSchedule> GetAssignedSchedules();

        void AssignTask(AssignedTask assignedTask);
        void UnassignTask(AssignedTask assignedTask);
        List<AssignedTask> GetAssignedTasks();
    }
}

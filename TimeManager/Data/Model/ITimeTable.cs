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
        List<DateTimeBlock> GetWorkTimes(DateTime week);

        List<DateTimeBlock> GetAvailableTimes(DateTime week);
        bool IsAvailable(DateTimeBlock timeBlock);

        void AssignSchedule(AssignedSchedule assignedSchedule);
        void UnassignSchedule(AssignedSchedule assignedSchedule);
        List<AssignedSchedule> GetAssignedSchedules(DateTime week);

        void AssignTask(AssignedTask assignedTask);
        void UnassignTask(AssignedTask assignedTask);
        List<AssignedTask> GetAssignedTasks(DateTime week);
    }
}

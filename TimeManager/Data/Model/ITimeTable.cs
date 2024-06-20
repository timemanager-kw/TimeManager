using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TimeManager.Data.Model
{
    public interface ITimeTable
    {
        /* WorkTime Operations */
        // TODO: 주 단위로 확장
        void SetWorkTimes(List<DateTimeBlock> workTimes);
        List<DateTimeBlock> GetWorkTimes();
        List<WeeklyDateTimeBlock> GetWeeklyWorkTimes(Week week);

        /* AvailableTime Operations */
        List<DateTimeBlock> GetWeeklyAvailableTimes(Week week);
        List<DateTimeBlock> GetAvailableTimesInThisWeekAsOfNow();
        List<DateTimeBlock> GetAvailableTimesInDaysBlock(DateTimeBlock timeBlock);

        /* AssignedSchedule Operations */
        void AssignSchedule(long scheduleId, IEnumerable<DateTimeBlock> assignedTimeBlocks);
        void ReassignSchedule(long scheduleId, IEnumerable<DateTimeBlock> assignedTimeBlocks);
        void UnassignSchedule(long scheduleId);
        List<AssignedSchedule> GetAssignedSchedulesByScheduleId(long scheduleId);
        List<AssignedSchedule> GetAllAssignedSchedules();
        List<AssignedSchedule> GetAllAssignedSchedulesAsOfNow();
        List<AssignedSchedule> GetWeeklyAssignedSchedules(Week week);
        List<AssignedSchedule> GetAssignedSchedulesInThisWeekAsOfNow();
        List<AssignedSchedule> GetAssignedSchedulesInBlock(DateTimeBlock timeBlock);

        /* AssignedTask Operations */
        void AssignTask(long taskId, IEnumerable<DateTimeBlock> assignedTimeBlocks);
        void ReassignTask(long taskId, IEnumerable<DateTimeBlock> assignedTimeBlocks);
        void UnassignTask(long taskId);
        List<AssignedTask> GetAssignedTasksByTaskId(long taskId);
        List<AssignedTask> GetAllAssignedTasks();
        List<AssignedTask> GetAllAssignedTasksAsOfNow();
        List<AssignedTask> GetWeeklyAssignedTasks(Week week);
        List<AssignedTask> GetAssignedTasksInThisWeekAsOfNow();
        List<AssignedTask> GetAssignedTasksInBlock(DateTimeBlock timeBlock);
    }
}

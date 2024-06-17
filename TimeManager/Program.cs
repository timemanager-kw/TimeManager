using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using TimeManager.Data.Manager;
using TimeManager.Data.Repository;
using TimeManager.Forms;

namespace TimeManager
{
    internal static class Program
    {
        static string TimeTablePath = "TimeTableRepository";
        static string SchedulePath = "TimeTableRepository";
        static string TaskPath = "TimeTableRepository";

        static FileTimeTableRepository fileTimeTableRepository = new FileTimeTableRepository(TimeTablePath);
        static FileScheduleRepository fileScheduleRepository = new FileScheduleRepository(SchedulePath);
        static FileTaskRepository fileTaskRepository = new FileTaskRepository(TaskPath);

        static TimeTableManager timeTableManager = new TimeTableManager(fileTimeTableRepository);
        static ScheduleManager scheduleManager = new ScheduleManager(fileScheduleRepository);
        static TaskManager taskManager = new TaskManager(fileTaskRepository);

        /// <summary>
        /// 해당 애플리케이션의 주 진입점입니다.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainForm(timeTableManager, scheduleManager, taskManager));
        }
    }
}

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
        static string TimeTablePath = Path.Combine(Path.GetDirectoryName(System.Diagnostics.Process.GetCurrentProcess().MainModule.FileName), "TimeTablePath");
        static string SchedulePath = Path.Combine(Path.GetDirectoryName(System.Diagnostics.Process.GetCurrentProcess().MainModule.FileName), "SchedulePath");
        static string TaskPath = Path.Combine(Path.GetDirectoryName(System.Diagnostics.Process.GetCurrentProcess().MainModule.FileName), "TaskPath");

        static FileTimeTableRepository FileTimeTableRepository = new FileTimeTableRepository(TimeTablePath);
        static FileScheduleRepository FileScheduleRepository = new FileScheduleRepository(SchedulePath);
        static FileTaskRepository FileTaskRepository = new FileTaskRepository(TaskPath);

        static TimeTableManager TimeTableManager = new TimeTableManager(FileTimeTableRepository);
        static ScheduleManager ScheduleManager = new ScheduleManager(FileScheduleRepository);
        static TaskManager TaskManager = new TaskManager(FileTaskRepository);

        /// <summary>
        /// 해당 애플리케이션의 주 진입점입니다.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainForm(TimeTableManager, ScheduleManager, TaskManager));
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TimeManager.Data.Model;

namespace TimeManager.Controls
{
    public enum EAssignedItemType
    {
        Schedule,
        Task
    }

    public class WeeklyTimeTableControlItemEventArgs : EventArgs
    {
        public EAssignedItemType AssignedItemType { get; set; }
        public int AssignedItemId { get; set; }
    }
}

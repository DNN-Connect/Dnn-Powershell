namespace Connect.DNN.Powershell.Core.Models
{
    public class TaskModelBase
    {
        public int ScheduleId { get; set; }
        public string FriendlyName { get; set; }
        public string NextStart { get; set; }
        public bool Enabled { get; set; }
    }
}

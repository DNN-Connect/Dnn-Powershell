namespace Connect.DNN.Powershell.Core.Models
{
    public class TaskModel : TaskModelBase
    {
        public string TypeName { get; set; }
        public bool CatchUp { get; set; }
        public string Created { get; set; }
        public string StartDate { get; set; }
    }
}

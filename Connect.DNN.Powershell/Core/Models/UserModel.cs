namespace Connect.DNN.Powershell.Core.Models
{
    public class UserModel: UserModelBase
    {
        public string DisplayName { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string LastActivity { get; set; }
        public string LastLockout { get; set; }
        public string LastPasswordChange { get; set; }
        public string Created { get; set; }
    }
}

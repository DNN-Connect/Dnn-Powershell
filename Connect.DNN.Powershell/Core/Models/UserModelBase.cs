namespace Connect.DNN.Powershell.Core.Models
{
    public class UserModelBase
    {
        public int UserId { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public string LastLogin { get; set; }
        public bool IsDeleted { get; set; }
        public bool IsAuthorized { get; set; }
        public bool IsLockedOut { get; set; }
    }
}

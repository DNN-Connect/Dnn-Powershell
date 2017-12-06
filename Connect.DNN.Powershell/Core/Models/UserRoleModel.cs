namespace Connect.DNN.Powershell.Core.Models
{
    public class UserRoleModel
    {
        public int RoleId { get; set; }
        public string RoleName { get; set; }
        public bool IsPublic { get; set; }
        public int PortalId { get; set; }
        public int UserRoleId { get; set; }
        public string Start { get; set; }
        public string End { get; set; }
    }
}

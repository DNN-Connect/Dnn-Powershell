namespace Connect.DNN.Powershell.Core.Models
{
    public class RoleBase
    {
        public int RoleId { get; set; }
        public int RoleGroupId { get; set; }
        public string RoleName { get; set; }
        public bool IsPublic { get; set; }
        public bool AutoAssign { get; set; }
        public int UserCount { get; set; }
        public string ModifiedDate { get; set; }
        public int ModifiedBy { get; set; }
    }
}

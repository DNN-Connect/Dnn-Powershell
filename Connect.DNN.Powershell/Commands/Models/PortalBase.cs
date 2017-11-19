namespace Connect.DNN.Powershell.Commands.Models
{
    public class PortalBase
    {
        public int PortalId { get; set; }
        public string PortalName { get; set; }
        public string RegistrationMode { get; set; }
        public string DefaultPortalAlias { get; set; }
        public int PageCount { get; set; }
        public int UserCount { get; set; }
        public string Language { get; set; }
    }
}

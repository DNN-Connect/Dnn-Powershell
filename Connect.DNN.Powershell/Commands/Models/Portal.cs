namespace Connect.DNN.Powershell.Commands.Models
{
    public class Portal: PortalBase
    {
        public int CdfVersion { get; set; }
        public string SiteTheme { get; set; }
        public string AdminTheme { get; set; }
        public string Container { get; set; }
        public string AdminContainer { get; set; }
    }
}

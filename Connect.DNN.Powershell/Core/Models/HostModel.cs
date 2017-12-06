namespace Connect.DNN.Powershell.Core.Models
{
    public class HostModel
    {
        // DNN Platform for example
        public string Product { get; set; }
        public string Version { get; set; }
        public bool UpgradeAvailable { get; set; }
        // .NET Framework: 4.6 for example
        public string Framework { get; set; }
        // Could be IPv6
        public string IpAddress { get; set; }
        // ReflectionPermission, WebPermission, AspNetHostingPermission, etc.
        public string Permissions { get; set; }
        // prompt.com
        public string Site { get; set; }
        public string Title { get; set; }
        public string Url { get; set; }
        public string Email { get; set; }
        public string Theme { get; set; }
        public string Container { get; set; }
        public string EditTheme { get; set; }
        public string EditContainer { get; set; }
        public int PortalCount { get; set; }
    }
}

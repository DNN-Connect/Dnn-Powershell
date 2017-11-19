using Connect.DNN.Powershell.Data;
using Connect.DNN.Powershell.Framework;
using System.Management.Automation;

namespace Connect.DNN.Powershell.Commands.SiteManagement
{
    [Cmdlet("Add", "Site")]
    public class AddSite: PSCmdlet
    {
        [Parameter(Position = 0, Mandatory = true)]
        public string Key { get; set; }

        [Parameter(Position = 1, Mandatory = true)]
        public string Url { get; set; }

        [Parameter(Position = 2, Mandatory = true)]
        public string Username { get; set; }

        [Parameter(Position = 3, Mandatory = true)]
        public string Password { get; set; }

        protected override void ProcessRecord()
        {
            Url = Url.TrimEnd('/');
            WriteVerbose(string.Format("Adding site {0} to your site list", Url));
            var result = DnnPromptController.GetToken(Url, Username, Password);
            var sites = SiteList.Instance();
            sites.SetSite(Key, Url, result.Contents);
            WriteObject(result.Status);
        }
    }
}

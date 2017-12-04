using Connect.DNN.Powershell.Common;
using Connect.DNN.Powershell.Data;
using Connect.DNN.Powershell.Framework;
using Connect.DNN.Powershell.Framework.Models;
using System.Management.Automation;

namespace Connect.DNN.Powershell.Commands.ContextManagement
{
    [Cmdlet("Add", "Site")]
    public class AddSite: BaseCmdLet
    {
        [Parameter(Position = 0, Mandatory = true)]
        public string Key { get; set; }

        [Parameter(Position = 1, Mandatory = true)]
        public string Url { get; set; }

        [Parameter(Position = 2, Mandatory = false)]
        public string Username { get; set; }

        [Parameter(Position = 3, Mandatory = false)]
        public string Password { get; set; }

        protected override void ProcessRecord()
        {
            Url = Url.TrimEnd('/');
            WriteVerbose(string.Format("Adding site {0} to your site list", Url));
            if (string.IsNullOrEmpty(Username) || string.IsNullOrEmpty(Password))
            {
                var creds = GetLogin();
                Username = creds.Username;
                Password = creds.Password.ToUnsecureString();
            }
            var result = DnnPromptController.GetToken(Url, Username, Password);
            var retries = 3;
            while (retries > 0 && result.Status == ServerResponseStatus.Failed)
            {
                WriteWarning("Login failed. Please provide username and password again.");
                var creds = GetLogin();
                result = DnnPromptController.GetToken(Url, creds.Username, creds.Password.ToUnsecureString());
                retries--;
            }
            if (result.Status == ServerResponseStatus.Success)
            {
                var sites = SiteList.Instance();
                sites.SetSite(Key, Url, result.Contents, true);
            }
            WriteObject(result.Status);
        }
    }
}

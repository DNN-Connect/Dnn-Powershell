using Connect.DNN.Powershell.Common;
using Connect.DNN.Powershell.Data;
using Connect.DNN.Powershell.Framework;
using System.Management.Automation;

namespace Connect.DNN.Powershell.Commands.SiteManagement
{
    [Cmdlet("Use", "Site")]
    public class UseSite : PSCmdlet
    {
        [Parameter(Position = 0, Mandatory = true, ParameterSetName = "keyonly")]
        public string Key { get; set; }

        [Parameter(Position = 0, Mandatory = true, ParameterSetName = "fullsite")]
        public string Url { get; set; }

        [Parameter(Position = 1, Mandatory = true, ParameterSetName = "fullsite")]
        public string Username { get; set; }

        [Parameter(Position = 2, Mandatory = true, ParameterSetName = "fullsite")]
        public string Password { get; set; }

        protected override void ProcessRecord()
        {
            if (ParameterSetName == "keyonly")
            {
                WriteVerbose(string.Format("Switching to site {0}", Key));
                var site = SiteList.Instance().Sites[Key];
                if (site != null)
                {
                    var result = DnnPromptController.ProcessCommand(site, 5, "echo Hello World");
                    DnnPromptController.CurrentSite = site;
                    WriteVerbose(string.Format("Switched to site {0}", Key));
                }
            }
            else
            {
                WriteVerbose(string.Format("Setting site to {0}", Url));
                var result = DnnPromptController.GetToken(Url, Username, Password);
                if (result.Status == ServerResponseStatus.Success)
                {
                    DnnPromptController.CurrentSite = new Site()
                    {
                        Url = Url,
                        Token = result.Contents.Encrypt()
                    };
                    WriteVerbose(string.Format("Success! Switched to site {0}", Url));
                }
                else
                {
                    WriteVerbose(string.Format("Error! Could not log in to site {0}", Url));
                }
            }
        }
    }
}

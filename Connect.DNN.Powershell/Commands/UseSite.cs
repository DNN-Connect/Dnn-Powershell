using Connect.DNN.Powershell.Data;
using Connect.DNN.Powershell.Framework;
using Connect.DNN.Powershell.Framework.Models;
using System.Management.Automation;

namespace Connect.DNN.Powershell.Commands
{
    [Cmdlet("Use", "Site")]
    public class UseSite : PSCmdlet
    {
        [Parameter(Position = 0, Mandatory = true)]
        public string Key { get; set; }

        protected override void ProcessRecord()
        {
            WriteVerbose(string.Format("Switching to site {0}", Key));
            var result = DnnPromptController.ProcessCommand(Key, 5, "echo Hello World");
            var site = SiteList.Instance().Sites[Key];
            if (site != null)
            {
                DnnPromptController.CurrentSiteKey = Key;
                WriteVerbose(string.Format("Switched to site {0}", Key));
            }
        }
    }
}

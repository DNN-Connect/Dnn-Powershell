using Connect.DNN.Powershell.Data;
using Connect.DNN.Powershell.Framework;
using Connect.DNN.Powershell.Framework.Models;
using System.Management.Automation;

namespace Connect.DNN.Powershell.Commands.SiteManagement
{
    [Cmdlet("Check", "Site")]
    public class CheckSite : DnnPromptCmdLet
    {
        protected override void ProcessRecord()
        {
            if (!FindSite()) { return; };
            WriteVerbose(string.Format("Checking site {0}", Key));
            var site = SiteList.Instance().Sites[Key];
            if (site != null)
            {
                var result = DnnPromptController.ProcessCommand(site, 5, "echo Hello World");
                WriteObject(result.Status);
            }
        }
    }
}

using Connect.DNN.Powershell.Framework;
using System.Management.Automation;

namespace Connect.DNN.Powershell.Commands
{
    [Cmdlet("Current", "Site")]
    public class CurrentSite : PSCmdlet
    {
        protected override void ProcessRecord()
        {
            if (string.IsNullOrEmpty(DnnPromptController.CurrentSiteKey))
            {
                WriteVerbose("No current site set. Use 'use-site {key}' to set a current site.");
            }
            else
            {
                WriteVerbose(string.Format("Current site is {0}", DnnPromptController.CurrentSiteKey));
            }
        }
    }
}

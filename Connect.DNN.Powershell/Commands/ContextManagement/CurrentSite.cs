using Connect.DNN.Powershell.Framework;
using System.Management.Automation;

namespace Connect.DNN.Powershell.Commands.ContextManagement
{
    [Cmdlet("Current", "Site")]
    public class CurrentSite : PSCmdlet
    {
        protected override void ProcessRecord()
        {
            if (DnnPromptController.CurrentSite == null)
            {
                WriteObject("No current site set. Use 'use-site {key}' to set a current site.");
            }
            else
            {
                WriteObject(DnnPromptController.CurrentSite);
            }
        }
    }
}

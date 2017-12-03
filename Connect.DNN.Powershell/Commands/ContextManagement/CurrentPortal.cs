using Connect.DNN.Powershell.Framework;
using System.Management.Automation;

namespace Connect.DNN.Powershell.Commands.ContextManagement
{
    [Cmdlet("Current", "Portal")]
    public class CurrentPortal : PSCmdlet
    {
        protected override void ProcessRecord()
        {
            if (DnnPromptController.CurrentPortal == null)
            {
                WriteObject("No current portal set. Use 'use-portal {id}' to set a current portal by ID.");
            }
            else
            {
                WriteObject(DnnPromptController.CurrentPortal);
            }
        }
    }
}

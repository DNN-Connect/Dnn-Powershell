using Connect.DNN.Powershell.Framework;
using Connect.DNN.Powershell.Framework.Models;
using System.Management.Automation;

namespace Connect.DNN.Powershell.Commands.ContextManagement
{
    [Cmdlet("Use", "Portal")]
    public class UsePortal : DnnPromptCmdLet
    {
        [Parameter(Position = 0, Mandatory = true)]
        public int Id { get; set; }

        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            if (CmdSite == null) { return; };
            DnnPromptController.CurrentPortal = DnnPromptController.CurrentSite.Portals[Id];
            WriteVerbose(string.Format("Portal set to {0}", DnnPromptController.CurrentPortal.PortalName));
            WriteObject(DnnPromptController.CurrentPortal);
        }
    }
}

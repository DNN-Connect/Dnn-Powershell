using Connect.DNN.Powershell.Data;
using System.Management.Automation;

namespace Connect.DNN.Powershell.Framework.Models
{
    public class DnnPromptPortalCmdLet : DnnPromptCmdLet
    {
        [Parameter(Mandatory = false)]
        public int? PortalId { get; set; }

        protected Portal CmdPortal { get; private set; }

        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            CmdPortal = DnnPromptController.CurrentPortal;
            if (CmdSite != null && PortalId != null)
            {
                if (CmdSite.Portals.ContainsKey((int)PortalId))
                {
                    CmdPortal = CmdSite.Portals[(int)PortalId];
                }
                else
                {
                    CmdPortal = new Portal() { PortalId = (int)PortalId, PortalName = "" };
                }
            }
        }
    }
}

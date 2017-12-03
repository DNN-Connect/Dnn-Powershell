using Connect.DNN.Powershell.Core.Commands;
using Connect.DNN.Powershell.Framework.Models;
using System.Management.Automation;

namespace Connect.DNN.Powershell.Commands.Portal
{
    [Cmdlet("Get", "Portal")]
    public class GetPortal : DnnPromptPortalCmdLet
    {
        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            if (CmdSite == null) { return; };
            WriteVerbose(string.Format("get-portal {1} on {0}", CmdSite.Url, PortalId));
            var response = CmdPortal == null ? PortalCommands.GetPortal(CmdSite) : PortalCommands.GetPortal(CmdSite, CmdPortal.PortalId);
            WriteObject(response);
        }
    }
}

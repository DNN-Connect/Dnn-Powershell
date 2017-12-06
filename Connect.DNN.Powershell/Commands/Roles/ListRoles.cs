using Connect.DNN.Powershell.Core.Commands;
using Connect.DNN.Powershell.Framework.Models;
using System.Management.Automation;

namespace Connect.DNN.Powershell.Commands.Roles
{
    [Cmdlet("List", "Roles")]
    public class ListRoles : DnnPromptPortalCmdLet
    {
        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            if (CmdSite == null || CmdPortal == null) { return; };
            WriteVerbose(string.Format("list-roles on {0} portal {1}", CmdSite.Url, CmdPortal.PortalId));
            var response = RoleCommands.ListRoles(CmdSite, CmdPortal.PortalId);
            WriteObject(response);
        }
    }
}

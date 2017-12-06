using Connect.DNN.Powershell.Core.Commands;
using Connect.DNN.Powershell.Framework.Models;
using System.Management.Automation;

namespace Connect.DNN.Powershell.Commands.Roles
{
    [Cmdlet("Delete", "Role")]
    public class DeleteRole : DnnPromptPortalCmdLet
    {
        [Parameter(Mandatory = true)]
        public int RoleId { get; set; }

        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            if (CmdSite == null || CmdPortal == null) { return; };
            WriteVerbose(string.Format("delete-role on {0} portal {1}", CmdSite.Url, CmdPortal.PortalId));
            var response = RoleCommands.DeleteRole(CmdSite, CmdPortal.PortalId, RoleId);
            WriteObject(response);
        }
    }
}

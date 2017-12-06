using Connect.DNN.Powershell.Core.Commands;
using Connect.DNN.Powershell.Framework.Models;
using System.Management.Automation;

namespace Connect.DNN.Powershell.Commands.Roles
{
    [Cmdlet("New", "Role")]
    public class NewRole : DnnPromptPortalCmdLet
    {
        [Parameter(Mandatory = true)]
        public string RoleName { get; set; }

        [Parameter(Mandatory = false)]
        public string Description { get; set; }

        [Parameter(Mandatory = false)]
        public bool? Public { get; set; }

        [Parameter(Mandatory = false)]
        public bool? AutoAssign { get; set; }

        [Parameter(Mandatory = false)]
        public string Status { get; set; }

        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            if (CmdSite == null || CmdPortal == null) { return; };
            WriteVerbose(string.Format("new-role on {0} portal {1}", CmdSite.Url, CmdPortal.PortalId));
            var response = RoleCommands.NewRole(CmdSite, CmdPortal.PortalId, RoleName, Description, Public, AutoAssign, Common.Globals.ToEnum(Status, RoleCommands.RoleStatus.Approved));
            WriteObject(response);
        }
    }
}

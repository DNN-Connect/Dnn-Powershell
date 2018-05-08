using Connect.DNN.Powershell.Core.Commands;
using Connect.DNN.Powershell.Framework.Models;
using System.Management.Automation;

namespace Connect.DNN.Powershell.Commands.Roles
{
    [Cmdlet("Set", "Role")]
    public class SetRole : DnnPromptPortalCmdLet
    {
        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true)]
        public int RoleId { get; set; }

        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true)]
        public string RoleName { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true)]
        public string Description { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true)]
        public bool? Public { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true)]
        public bool? AutoAssign { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true)]
        public string Status { get; set; }

        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            if (CmdSite == null || CmdPortal == null) { return; };
            WriteVerbose(string.Format("set-role on {0} portal {1}", CmdSite.Url, CmdPortal.PortalId));
            var response = RoleCommands.SetRole(CmdSite, CmdPortal.PortalId, RoleId, RoleName, Description, Public, AutoAssign, Common.Globals.ToEnum(Status, RoleCommands.RoleStatus.Approved));
            WriteObject(response);
        }
    }
}

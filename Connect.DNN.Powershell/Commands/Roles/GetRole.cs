using Connect.DNN.Powershell.Core.Commands;
using Connect.DNN.Powershell.Framework.Models;
using System.Management.Automation;

namespace Connect.DNN.Powershell.Commands.Roles
{
    [Cmdlet("Get", "Role")]
    public class GetRole : DnnPromptPortalCmdLet
    {
        [Parameter(Mandatory = true, ValueFromPipeline = true, ValueFromPipelineByPropertyName = true)]
        public int RoleId { get; set; }

        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            if (CmdSite == null || CmdPortal == null) { return; };
            WriteVerbose(string.Format("get-role on {0} portal {1}", CmdSite.Url, CmdPortal.PortalId));
            var response = RoleCommands.GetRole(CmdSite, CmdPortal.PortalId, RoleId);
            WriteObject(response);
        }
    }
}

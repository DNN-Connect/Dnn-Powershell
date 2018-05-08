using Connect.DNN.Powershell.Core.Commands;
using Connect.DNN.Powershell.Framework.Models;
using System.Management.Automation;

namespace Connect.DNN.Powershell.Commands.User
{
    [Cmdlet("Add", "Roles")]
    public class AddRoles : DnnPromptPortalCmdLet
    {
        [Parameter(Mandatory = true, ValueFromPipeline = true, ValueFromPipelineByPropertyName = true)]
        public int UserId { get; set; }

        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true)]
        public string Roles { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true)]
        public System.DateTime? Start { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true)]
        public System.DateTime? End { get; set; }

        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            if (CmdSite == null || CmdPortal == null) { return; };
            WriteVerbose(string.Format("add-roles on {0} portal {1}", CmdSite.Url, CmdPortal.PortalId));
            var response = UserCommands.AddRoles(CmdSite, CmdPortal.PortalId, UserId, Roles, Start, End);
            WriteObject(response);
        }
    }
}

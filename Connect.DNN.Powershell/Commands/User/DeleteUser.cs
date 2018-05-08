using Connect.DNN.Powershell.Core.Commands;
using Connect.DNN.Powershell.Framework.Models;
using System.Management.Automation;

namespace Connect.DNN.Powershell.Commands.User
{
    [Cmdlet("Delete", "User")]
    public class DeleteUser : DnnPromptPortalCmdLet
    {
        [Parameter(Mandatory = true, ValueFromPipeline = true, ValueFromPipelineByPropertyName = true)]
        public int UserId { get; set; }

        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true)]
        public bool? Notify { get; set; }

        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            if (CmdSite == null || CmdPortal == null) { return; };
            WriteVerbose(string.Format("delete-user on {0} portal {1}", CmdSite.Url, CmdPortal.PortalId));
            var response = UserCommands.DeleteUser(CmdSite, CmdPortal.PortalId, UserId, Notify);
            WriteObject(response);
        }
    }
}

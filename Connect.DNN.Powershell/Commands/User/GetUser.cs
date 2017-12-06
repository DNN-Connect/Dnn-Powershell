using Connect.DNN.Powershell.Core.Commands;
using Connect.DNN.Powershell.Framework.Models;
using System.Management.Automation;

namespace Connect.DNN.Powershell.Commands.User
{
    [Cmdlet("Get", "User")]
    public class GetUser : DnnPromptPortalCmdLet
    {
        [Parameter(Mandatory = false)]
        public int UserId { get; set; }

        [Parameter(Mandatory = false)]
        public string Email { get; set; }

        [Parameter(Mandatory = false)]
        public string Username { get; set; }

        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            if (CmdSite == null || CmdPortal == null) { return; };
            WriteVerbose(string.Format("get-user on {0} portal {1}", CmdSite.Url, CmdPortal.PortalId));
            var response = UserCommands.GetUser(CmdSite, CmdPortal.PortalId, UserId, Email, Username);
            WriteObject(response);
        }
    }
}

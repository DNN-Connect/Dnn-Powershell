using Connect.DNN.Powershell.Core.Commands;
using Connect.DNN.Powershell.Core.Models;
using Connect.DNN.Powershell.Framework.Models;
using System.Management.Automation;

namespace Connect.DNN.Powershell.Commands.User
{
    [Cmdlet("List", "Users")]
    public class ListUsers : DnnPromptPortalCmdLet
    {
        [Parameter(Mandatory = false)]
        public string Email { get; set; }

        [Parameter(Mandatory = false)]
        public string Username { get; set; }

        [Parameter(Mandatory = false)]
        public string Role { get; set; }

        [Parameter(Mandatory = false)]
        public int? Page { get; set; }

        [Parameter(Mandatory = false)]
        public int? Max { get; set; }

        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            if (CmdSite == null || CmdPortal == null) { return; };
            WriteVerbose(string.Format("list-users on {0} portal {1}", CmdSite.Url, CmdPortal.PortalId));
            var response = UserCommands.ListUsers(CmdSite, CmdPortal.PortalId, Email, Username, Role, Page, Max);
            foreach (UserModelBase user in response)
            {
                WriteObject(user);
            }
        }
    }
}

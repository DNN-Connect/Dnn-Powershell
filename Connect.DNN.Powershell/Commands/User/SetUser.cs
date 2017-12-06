using Connect.DNN.Powershell.Core.Commands;
using Connect.DNN.Powershell.Framework.Models;
using System.Management.Automation;

namespace Connect.DNN.Powershell.Commands.User
{
    [Cmdlet("Set", "User")]
    public class SetUser : DnnPromptPortalCmdLet
    {
        [Parameter(Mandatory = true)]
        public int UserId { get; set; }

        [Parameter(Mandatory = false)]
        public string Email { get; set; }

        [Parameter(Mandatory = false)]
        public string Username { get; set; }

        [Parameter(Mandatory = false)]
        public string Displayname { get; set; }

        [Parameter(Mandatory = false)]
        public string Firstname { get; set; }

        [Parameter(Mandatory = false)]
        public string Lastname { get; set; }

        [Parameter(Mandatory = false)]
        public string Password { get; set; }

        [Parameter(Mandatory = false)]
        public bool? Approved { get; set; }

        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            if (CmdSite == null || CmdPortal == null) { return; };
            WriteVerbose(string.Format("set-user on {0} portal {1}", CmdSite.Url, CmdPortal.PortalId));
            var response = UserCommands.SetUser(CmdSite, CmdPortal.PortalId, UserId, Email, Username, Displayname, Firstname, Lastname, Password, Approved);
            WriteObject(response);
        }
    }
}

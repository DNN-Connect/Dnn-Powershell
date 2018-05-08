using Connect.DNN.Powershell.Core.Commands;
using Connect.DNN.Powershell.Framework.Models;
using System.Management.Automation;

namespace Connect.DNN.Powershell.Commands.User
{
    [Cmdlet("New", "User")]
    public class NewUser : DnnPromptPortalCmdLet
    {
        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true)]
        public string Email { get; set; }

        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true)]
        public string Username { get; set; }

        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true)]
        public string Firstname { get; set; }

        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true)]
        public string Lastname { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true)]
        public string Password { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true)]
        public bool? Approved { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true)]
        public bool? Notify { get; set; }

        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            if (CmdSite == null || CmdPortal == null) { return; };
            WriteVerbose(string.Format("new-user on {0} portal {1}", CmdSite.Url, CmdPortal.PortalId));
            var response = UserCommands.NewUser(CmdSite, CmdPortal.PortalId, Email, Username, Firstname, Lastname, Password, Approved, Notify);
            WriteObject(response);
        }
    }
}

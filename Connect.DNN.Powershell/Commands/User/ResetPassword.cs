using Connect.DNN.Powershell.Core.Commands;
using Connect.DNN.Powershell.Framework.Models;
using System.Management.Automation;

namespace Connect.DNN.Powershell.Commands.User
{
    [Cmdlet("Reset", "Password")]
    public class ResetPassword : DnnPromptPortalCmdLet
    {
        [Parameter(Mandatory = true)]
        public int UserId { get; set; }

        [Parameter(Mandatory = true)]
        public bool? Notify { get; set; }

        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            if (CmdSite == null || CmdPortal == null) { return; };
            WriteVerbose(string.Format("reset-password on {0} portal {1}", CmdSite.Url, CmdPortal.PortalId));
            var response = UserCommands.ResetPassword(CmdSite, CmdPortal.PortalId, UserId, Notify);
            WriteObject(response);
        }
    }
}

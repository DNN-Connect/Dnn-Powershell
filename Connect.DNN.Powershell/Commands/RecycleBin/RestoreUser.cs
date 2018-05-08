using Connect.DNN.Powershell.Core.Commands;
using Connect.DNN.Powershell.Framework.Models;
using System.Management.Automation;

namespace Connect.DNN.Powershell.Commands.RecycleBin
{
    [Cmdlet("Restore", "User")]
    public class RestoreUser : DnnPromptPortalCmdLet
    {
        [Parameter(Mandatory = true, ValueFromPipeline = true, ValueFromPipelineByPropertyName = true)]
        public int UserId { get; set; }

        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            if (CmdSite == null || CmdPortal == null) { return; };
            WriteVerbose(string.Format("restore-user on {0} portal {1}", CmdSite.Url, CmdPortal.PortalId));
            var response = RecyclebinCommands.RestoreUser(CmdSite, CmdPortal.PortalId, UserId);
            WriteObject(response);
        }
    }
}

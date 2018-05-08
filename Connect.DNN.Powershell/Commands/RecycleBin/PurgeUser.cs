using Connect.DNN.Powershell.Core.Commands;
using Connect.DNN.Powershell.Framework.Models;
using System.Management.Automation;

namespace Connect.DNN.Powershell.Commands.RecycleBin
{
    [Cmdlet("Purge", "User")]
    public class PurgeUser : DnnPromptPortalCmdLet
    {
        [Parameter(Mandatory = true, ValueFromPipeline = true, ValueFromPipelineByPropertyName = true)]
        public int UserId { get; set; }

        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            if (CmdSite == null || CmdPortal == null) { return; };
            WriteVerbose(string.Format("purge-user on {0} portal {1}", CmdSite.Url, CmdPortal.PortalId));
            var response = RecyclebinCommands.PurgeUser(CmdSite, CmdPortal.PortalId, UserId);
            WriteObject(response);
        }
    }
}

using Connect.DNN.Powershell.Core.Commands;
using Connect.DNN.Powershell.Framework.Models;
using System.Management.Automation;

namespace Connect.DNN.Powershell.Commands.RecycleBin
{
    [Cmdlet("Purge", "Page")]
    public class PurgePage : DnnPromptPortalCmdLet
    {
        [Parameter(Mandatory = true)]
        public int PageId { get; set; }

        [Parameter(Mandatory = false)]
        public bool? DeleteChildren { get; set; }

        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            if (CmdSite == null || CmdPortal == null) { return; };
            WriteVerbose(string.Format("purge-page on {0} portal {1}", CmdSite.Url, CmdPortal.PortalId));
            var response = RecyclebinCommands.PurgePage(CmdSite, CmdPortal.PortalId, PageId, DeleteChildren);
            WriteObject(response);
        }
    }
}

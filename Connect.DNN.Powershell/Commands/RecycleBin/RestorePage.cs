using Connect.DNN.Powershell.Core.Commands;
using Connect.DNN.Powershell.Framework.Models;
using System.Management.Automation;

namespace Connect.DNN.Powershell.Commands.RecycleBin
{
    [Cmdlet("Restore", "Page")]
    public class RestorePage : DnnPromptPortalCmdLet
    {
        [Parameter(Mandatory = false, ValueFromPipeline = true, ValueFromPipelineByPropertyName = true)]
        public int? PageId { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true)]
        public string PageName { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true)]
        public int? ParentId { get; set; }

        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            if (CmdSite == null || CmdPortal == null) { return; };
            WriteVerbose(string.Format("RestorePage on {0} portal {1}", CmdSite.Url, CmdPortal.PortalId));
            var response = RecyclebinCommands.RestorePage(CmdSite, CmdPortal.PortalId, PageId, PageName, ParentId);
            WriteObject(response);
        }
    }
}

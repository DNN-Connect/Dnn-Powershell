using Connect.DNN.Powershell.Core.Commands;
using Connect.DNN.Powershell.Framework.Models;
using System.Management.Automation;

namespace Connect.DNN.Powershell.Commands.Page
{
    [Cmdlet("Delete", "Page")]
    public class DeletePage : DnnPromptPortalCmdLet
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
            WriteVerbose(string.Format("delete-page on {0} portal {1}", CmdSite.Url, CmdPortal.PortalId));
            var response = PageCommands.DeletePage(CmdSite, CmdPortal.PortalId, PageId, PageName, ParentId);
            WriteObject(response);
        }
    }
}

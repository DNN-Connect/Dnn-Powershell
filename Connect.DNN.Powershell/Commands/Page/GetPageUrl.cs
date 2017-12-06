using Connect.DNN.Powershell.Core.Commands;
using Connect.DNN.Powershell.Framework.Models;
using System.Management.Automation;

namespace Connect.DNN.Powershell.Commands.Page
{
    [Cmdlet("Get", "PageUrl")]
    public class GetPageUrl : DnnPromptPortalCmdLet
    {
        [Parameter(Mandatory = false)]
        public int? PageId { get; set; }

        [Parameter(Mandatory = false)]
        public string PageName { get; set; }

        [Parameter(Mandatory = false)]
        public int? ParentId { get; set; }

        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            if (CmdSite == null || CmdPortal == null) { return; };
            WriteVerbose(string.Format("goto on {0} portal {1}", CmdSite.Url, CmdPortal.PortalId));
            var response = PageCommands.GetPageUrl(CmdSite, CmdPortal.PortalId, PageId, PageName, ParentId);
            WriteObject(response);
        }
    }
}

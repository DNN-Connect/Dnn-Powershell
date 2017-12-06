using Connect.DNN.Powershell.Core.Commands;
using Connect.DNN.Powershell.Framework.Models;
using System.Management.Automation;

namespace Connect.DNN.Powershell.Commands.Page
{
    [Cmdlet("Set", "Page")]
    public class SetPage : DnnPromptPortalCmdLet
    {
        [Parameter(Mandatory = true)]
        public int PageId { get; set; }

        [Parameter(Mandatory = false)]
        public int? ParentId { get; set; }

        [Parameter(Mandatory = false)]
        public string PageTitle { get; set; }

        [Parameter(Mandatory = false)]
        public string PageName { get; set; }

        [Parameter(Mandatory = false)]
        public string Url { get; set; }

        [Parameter(Mandatory = false)]
        public string Description { get; set; }

        [Parameter(Mandatory = false)]
        public string Keywords { get; set; }

        [Parameter(Mandatory = false)]
        public bool? Visible { get; set; }

        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            if (CmdSite == null || CmdPortal == null) { return; };
            WriteVerbose(string.Format("set-page on {0} portal {1}", CmdSite.Url, CmdPortal.PortalId));
            var response = PageCommands.SetPage(CmdSite, CmdPortal.PortalId, PageId, ParentId, PageTitle, PageName, Url, Description, Keywords, Visible);
            WriteObject(response);
        }
    }
}

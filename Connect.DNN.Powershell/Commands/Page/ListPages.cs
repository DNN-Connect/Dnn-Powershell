using Connect.DNN.Powershell.Core.Commands;
using Connect.DNN.Powershell.Framework.Models;
using System.Management.Automation;

namespace Connect.DNN.Powershell.Commands.Page
{
    [Cmdlet("List", "Pages")]
    public class ListPages : DnnPromptPortalCmdLet
    {
        [Parameter(Mandatory = false)]
        public int? ParentId { get; set; }

        [Parameter(Mandatory = false)]
        public bool? Deleted { get; set; }

        [Parameter(Mandatory = false)]
        public string PageName { get; set; }

        [Parameter(Mandatory = false)]
        public string PageTitle { get; set; }

        [Parameter(Mandatory = false)]
        public string Path { get; set; }

        [Parameter(Mandatory = false)]
        public string Skin { get; set; }

        [Parameter(Mandatory = false)]
        public bool? Visible { get; set; }

        [Parameter(Mandatory = false)]
        public int? Page { get; set; }

        [Parameter(Mandatory = false)]
        public int? Max { get; set; }

        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            if (CmdSite == null || CmdPortal == null) { return; };
            WriteVerbose(string.Format("list-pages on {0} portal {1}", CmdSite.Url, CmdPortal.PortalId));
            var response = PageCommands.ListPages(CmdSite, CmdPortal.PortalId, ParentId, Deleted, PageName, PageTitle, Path, Skin, Visible, Page, Max);
            WriteObject(response);
        }
    }
}

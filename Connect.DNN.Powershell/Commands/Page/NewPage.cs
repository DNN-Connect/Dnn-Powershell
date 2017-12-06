using Connect.DNN.Powershell.Core.Commands;
using Connect.DNN.Powershell.Framework;
using Connect.DNN.Powershell.Framework.Models;
using System.Management.Automation;

namespace Connect.DNN.Powershell.Commands.Page
{
    [Cmdlet("New", "Page")]
    public class NewPage : DnnPromptPortalCmdLet
    {
        [Parameter(Mandatory = false)]
        public int? ParentId { get; set; }

        [Parameter(Mandatory = false)]
        public string PageTitle { get; set; }

        [Parameter(Mandatory = true)]
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
            WriteVerbose(string.Format("new-page on {0} portal {1}", CmdSite.Url, CmdPortal.PortalId));
            var response = PageCommands.NewPage(CmdSite, CmdPortal.PortalId, ParentId, PageTitle, PageName, Url, Description, Keywords, Visible);
            WriteObject(response);
        }
    }
}

using Connect.DNN.Powershell.Core.Commands;
using Connect.DNN.Powershell.Framework.Models;
using System.Management.Automation;

namespace Connect.DNN.Powershell.Commands.Module
{
    [Cmdlet("Add", "DnnModule")]
    public class AddModule : DnnPromptPortalCmdLet
    {
        [Parameter(Mandatory = true)]
        public string ModuleName { get; set; }

        [Parameter(Mandatory = true)]
        public int PageId { get; set; }

        [Parameter(Mandatory = false)]
        public string PaneName { get; set; }

        [Parameter(Mandatory = false)]
        public string Title { get; set; }

        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            if (CmdSite == null || CmdPortal == null) { return; };
            WriteVerbose(string.Format("add-module on {0} portal {1}", CmdSite.Url, CmdPortal.PortalId));
            var response = ModuleCommands.AddModule(CmdSite, CmdPortal.PortalId, ModuleName, PageId, PaneName, Title);
            WriteObject(response);
        }
    }
}

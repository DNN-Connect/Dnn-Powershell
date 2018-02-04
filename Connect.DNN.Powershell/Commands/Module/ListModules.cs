using Connect.DNN.Powershell.Core.Commands;
using Connect.DNN.Powershell.Framework.Models;
using System.Management.Automation;

namespace Connect.DNN.Powershell.Commands.Module
{
    [Cmdlet("List", "DnnModules")]
    public class ListModules : DnnPromptPortalCmdLet
    {
        [Parameter(Mandatory = false)]
        public string ModuleName { get; set; }

        [Parameter(Mandatory = false)]
        public string ModuleTitle { get; set; }

        [Parameter(Mandatory = false)]
        public int? PageId { get; set; }

        [Parameter(Mandatory = false)]
        public bool? Deleted { get; set; }

        [Parameter(Mandatory = false)]
        public int? Page { get; set; }

        [Parameter(Mandatory = false)]
        public int? Max { get; set; }

        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            if (CmdSite == null || CmdPortal == null) { return; };
            WriteVerbose(string.Format("add-module on {0} portal {1}", CmdSite.Url, CmdPortal.PortalId));
            var response = ModuleCommands.ListModules(CmdSite, CmdPortal.PortalId, ModuleName, ModuleTitle, PageId, Deleted, Page, Max);
            WriteArray(response);
        }
    }
}

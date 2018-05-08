using Connect.DNN.Powershell.Core.Commands;
using Connect.DNN.Powershell.Framework.Models;
using System.Management.Automation;

namespace Connect.DNN.Powershell.Commands.Module
{
    [Cmdlet("Delete", "DnnModule")]
    public class DeleteModule : DnnPromptPortalCmdLet
    {
        [Parameter(Mandatory = true, ValueFromPipeline = true, ValueFromPipelineByPropertyName = true)]
        public int ModuleId { get; set; }

        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true)]
        public int PageId { get; set; }

        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            if (CmdSite == null || CmdPortal == null) { return; };
            WriteVerbose(string.Format("delete-module on {0} portal {1}", CmdSite.Url, CmdPortal.PortalId));
            var response = ModuleCommands.DeleteModule(CmdSite, CmdPortal.PortalId, ModuleId, PageId);
            WriteObject(response);
        }
    }
}

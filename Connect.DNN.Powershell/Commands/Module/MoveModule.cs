using Connect.DNN.Powershell.Core.Commands;
using Connect.DNN.Powershell.Framework.Models;
using System.Management.Automation;

namespace Connect.DNN.Powershell.Commands.Module
{
    [Cmdlet("Move", "DnnModule")]
    public class MoveModule : DnnPromptPortalCmdLet
    {
        [Parameter(Mandatory = true, ValueFromPipeline = true, ValueFromPipelineByPropertyName = true)]
        public int ModuleId { get; set; }

        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true)]
        public int PageId { get; set; }

        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true)]
        public int ToPageId { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true)]
        public string PaneName { get; set; }

        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            if (CmdSite == null || CmdPortal == null) { return; };
            WriteVerbose(string.Format("move-module on {0} portal {1}", CmdSite.Url, CmdPortal.PortalId));
            var response = ModuleCommands.MoveModule(CmdSite, CmdPortal.PortalId, ModuleId, PageId, ToPageId, PaneName);
            WriteObject(response);
        }
    }
}

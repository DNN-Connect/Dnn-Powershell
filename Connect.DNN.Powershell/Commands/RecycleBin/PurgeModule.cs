using Connect.DNN.Powershell.Core.Commands;
using Connect.DNN.Powershell.Framework.Models;
using System.Management.Automation;

namespace Connect.DNN.Powershell.Commands.RecycleBin
{
    [Cmdlet("Purge", "DnnModule")]
    public class PurgeModule : DnnPromptPortalCmdLet
    {
        [Parameter(Mandatory = true)]
        public int ModuleId { get; set; }

        [Parameter(Mandatory = true)]
        public int PageId { get; set; }

        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            if (CmdSite == null || CmdPortal == null) { return; };
            WriteVerbose(string.Format("purge-module on {0} portal {1}", CmdSite.Url, CmdPortal.PortalId));
            var response = RecyclebinCommands.PurgeModule(CmdSite, CmdPortal.PortalId, ModuleId, PageId);
            WriteObject(response);
        }
    }
}

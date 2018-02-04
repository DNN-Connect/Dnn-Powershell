using Connect.DNN.Powershell.Core.Commands;
using Connect.DNN.Powershell.Framework.Models;
using System.Management.Automation;

namespace Connect.DNN.Powershell.Commands.Portal
{
    [Cmdlet("List", "Portals")]
    public class ListPortals : DnnPromptCmdLet
    {
        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            if (CmdSite == null) { return; };
            WriteVerbose(string.Format("list-portals on {0}", CmdSite.Url));
            var response = PortalCommands.ListPortals(CmdSite);
            WriteArray(response);
        }
    }
}

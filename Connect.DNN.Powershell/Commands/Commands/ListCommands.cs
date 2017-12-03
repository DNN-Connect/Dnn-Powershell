using Connect.DNN.Powershell.Core.Commands;
using Connect.DNN.Powershell.Framework;
using Connect.DNN.Powershell.Framework.Models;
using System.Management.Automation;

namespace Connect.DNN.Powershell.Commands.Commands
{
    [Cmdlet("List", "Commands")]
    public class ListCommands : DnnPromptCmdLet
    {
        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            if (CmdSite == null) { return; };
            WriteVerbose(string.Format("list-commands on {0}", CmdSite.Url));
            var response = CommandCommands.ListCommands(CmdSite);
            WriteObject(response);
        }
    }
}

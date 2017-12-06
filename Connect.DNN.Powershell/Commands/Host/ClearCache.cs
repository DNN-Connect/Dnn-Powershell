using Connect.DNN.Powershell.Core.Commands;
using Connect.DNN.Powershell.Framework.Models;
using System.Management.Automation;

namespace Connect.DNN.Powershell.Commands.Host
{
    [Cmdlet("Clear", "Cache")]
    public class ClearCache : DnnPromptCmdLet
    {
        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            if (CmdSite == null) { return; };
            WriteVerbose(string.Format("clear-cache on {0}", CmdSite.Url));
            var response = HostCommands.ClearCache(CmdSite);
            WriteObject(response);
        }
    }
}

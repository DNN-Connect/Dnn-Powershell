using Connect.DNN.Powershell.Core.Commands;
using Connect.DNN.Powershell.Framework.Models;
using System.Management.Automation;

namespace Connect.DNN.Powershell.Commands.Host
{
    [Cmdlet("Get", "Host")]
    public class GetHost : DnnPromptCmdLet
    {
        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            if (CmdSite == null) { return; };
            WriteVerbose(string.Format("get-host on {0}", CmdSite.Url));
            var response = HostCommands.GetHost(CmdSite);
            WriteObject(response);
        }
    }
}

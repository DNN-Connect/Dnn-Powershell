using Connect.DNN.Powershell.Core.Commands;
using Connect.DNN.Powershell.Framework.Models;
using System.Management.Automation;

namespace Connect.DNN.Powershell.Commands.Application
{
    [Cmdlet("Restart", "Application")]
    public class RestartApplication : DnnPromptCmdLet
    {
        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            if (CmdSite == null) { return; };
            WriteVerbose(string.Format("restart-application on {0}", CmdSite.Url));
            var response = ApplicationCommands.RestartApplication(CmdSite);
            WriteObject(response);
        }
    }
}

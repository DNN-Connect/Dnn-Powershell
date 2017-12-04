using Connect.DNN.Powershell.Framework.Models;
using System.Management.Automation;

namespace Connect.DNN.Powershell.Commands.ContextManagement
{
    [Cmdlet("Check", "Site")]
    public class CheckSite : DnnPromptCmdLet
    {
        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            if (CmdSite == null) { return; };
            WriteVerbose(string.Format("Checking site {0}", CmdSite.Url));
            var res = CheckSite(CmdSite, Key);
            WriteObject(res);
        }
    }
}

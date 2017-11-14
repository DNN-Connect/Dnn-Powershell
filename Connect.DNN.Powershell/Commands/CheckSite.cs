using Connect.DNN.Powershell.Framework;
using Connect.DNN.Powershell.Framework.Models;
using System.Management.Automation;

namespace Connect.DNN.Powershell.Commands
{
    [Cmdlet("Check", "Site")]
    public class CheckSite : DnnPromptCmdLet
    {
        protected override void ProcessRecord()
        {
            if (!ParseKey()) { return; };
            WriteVerbose(string.Format("Checking site {0}", Key));
            var result = DnnPromptController.ProcessCommand(Key, 5, "echo Hello World");
            WriteObject(result.Status);
        }
    }
}

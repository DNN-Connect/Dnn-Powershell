using Connect.DNN.Powershell.Framework;
using System.Management.Automation;

namespace Connect.DNN.Powershell.Commands
{
    [Cmdlet("Check", "Site")]
    public class CheckSite : PSCmdlet
    {
        [Parameter(Position = 0, Mandatory = true)]
        public string Key { get; set; }

        protected override void ProcessRecord()
        {
            WriteVerbose(string.Format("Checking site {0}", Key));
            var result = DnnPromptController.ProcessCommand(Key, 5, "echo Hello World");
            WriteObject(result.Status);
        }
    }
}

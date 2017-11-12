using Connect.DNN.Powershell.Framework;
using Connect.DNN.Powershell.Framework.Models;
using System.Management.Automation;

namespace Connect.DNN.Powershell.Commands
{
    [Cmdlet("List", "Commands")]
    public class ListCommands: PSCmdlet
    {
        [Parameter(Position = 0, Mandatory = true)]
        public string Key { get; set; }

        protected override void ProcessRecord()
        {
            WriteVerbose(string.Format("list-commands on {0}", Key));
            var responseText = DnnPromptController.ProcessCommand(Key, "list-commands");
            WriteVerbose("Retrieved response");
            var result = Newtonsoft.Json.JsonConvert.DeserializeObject<ConsoleResultModel<Models.Command>>(responseText);
            WriteObject(result.Data);
        }
    }
}

using Connect.DNN.Powershell.Framework;
using Connect.DNN.Powershell.Framework.Models;
using System.Management.Automation;

namespace Connect.DNN.Powershell.Commands
{
    [Cmdlet("List", "Commands")]
    public class ListCommands : PSCmdlet
    {
        [Parameter(Position = 0, Mandatory = true)]
        public string Key { get; set; }

        protected override void ProcessRecord()
        {
            WriteVerbose(string.Format("list-commands on {0}", Key));
            var response = DnnPromptController.ProcessCommand(Key, 5, "list-commands");
            WriteVerbose(string.Format("Retrieved response {0}", response.Status));
            if (response.Status == ServerResponse.Success)
            {
                var result = Newtonsoft.Json.JsonConvert.DeserializeObject<ConsoleResultModel<Models.Command>>(response.Contents);
                WriteObject(result.Data);
            }
            else
            {
                WriteObject(response.Status);
            }
        }
    }
}

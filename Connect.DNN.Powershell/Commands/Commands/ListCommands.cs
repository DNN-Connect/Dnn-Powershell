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
            if (!FindSite()) { return; };
            WriteVerbose(string.Format("list-commands on {0}", CmdSite.Url));
            var response = DnnPromptController.ProcessCommand(CmdSite, 5, "list-commands");
            WriteVerbose(string.Format("Retrieved response {0}", response.Status));
            if (response.Status == ServerResponseStatus.Success)
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

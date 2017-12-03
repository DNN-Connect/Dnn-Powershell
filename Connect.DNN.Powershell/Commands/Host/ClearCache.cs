using Connect.DNN.Powershell.Framework;
using Connect.DNN.Powershell.Framework.Models;
using System.Management.Automation;

namespace Connect.DNN.Powershell.Commands.Host
{
    [Cmdlet("Clear", "Cache")]
    public class ClearCache : DnnPromptCmdLet
    {
        protected override void ProcessRecord()
        {
            if (!FindSite()) { return; };
            WriteVerbose(string.Format("clear-cache on {0}", CmdSite.Url));
            var response = DnnPromptController.ProcessCommand(CmdSite, 5, "clear-cache");
            WriteVerbose(string.Format("Retrieved response {0}", response.Status));
            if (response.Status == ServerResponseStatus.Success)
            {
                var result = Newtonsoft.Json.JsonConvert.DeserializeObject<ConsoleResultModel<object>>(response.Contents);
                WriteObject(result.Output);
            }
            else
            {
                WriteObject(response.Status);
            }
        }
    }
}

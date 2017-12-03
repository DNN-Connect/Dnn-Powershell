using Connect.DNN.Powershell.Framework;
using Connect.DNN.Powershell.Framework.Models;
using System.Management.Automation;

namespace Connect.DNN.Powershell.Commands.Host
{
    [Cmdlet("Get", "Host")]
    public class GetHost : DnnPromptCmdLet
    {
        protected override void ProcessRecord()
        {
            if (!FindSite()) { return; };
            WriteVerbose(string.Format("get-host on {0}", CmdSite.Url));
            var response = DnnPromptController.ProcessCommand(CmdSite, 5, "get-host");
            WriteVerbose(string.Format("Retrieved response {0}", response.Status));
            if (response.Status == ServerResponseStatus.Success)
            {
                var result = Newtonsoft.Json.JsonConvert.DeserializeObject<ConsoleResultModel<Models.HostModel>>(response.Contents);
                WriteObject(result.Data[0]); // there is only one host
            }
            else
            {
                WriteObject(response.Status);
            }
        }
    }
}

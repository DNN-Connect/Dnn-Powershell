using Connect.DNN.Powershell.Framework;
using Connect.DNN.Powershell.Framework.Models;
using System.Management.Automation;

namespace Connect.DNN.Powershell.Commands.Portals
{
    [Cmdlet("Get", "Portal")]
    public class GetPortal : DnnPromptCmdLet
    {
        [Parameter(Position = 0, Mandatory = true)]
        public int Id { get; set; }

        protected override void ProcessRecord()
        {
            if (!FindSite()) { return; };
            WriteVerbose(string.Format("get-portal {1} on {0}", CmdSite.Url, Id));
            var response = DnnPromptController.ProcessCommand(CmdSite, 5, string.Format("get-portal --id {0}", Id));
            WriteVerbose(string.Format("Retrieved response {0}", response.Status));
            if (response.Status == ServerResponseStatus.Success)
            {
                var result = Newtonsoft.Json.JsonConvert.DeserializeObject<ConsoleResultModel<Models.Portal>>(response.Contents);
                WriteObject(result.Data);
            }
            else
            {
                WriteObject(response.Status);
            }
        }
    }
}

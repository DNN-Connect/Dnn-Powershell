using Connect.DNN.Powershell.Framework;
using Connect.DNN.Powershell.Framework.Models;
using System.Management.Automation;

namespace Connect.DNN.Powershell.Commands.ContextManagement
{
    [Cmdlet("Use", "Portal")]
    public class UsePortal : DnnPromptCmdLet
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
                if (result.Data.Length > 0)
                {
                    DnnPromptController.CurrentPortal = result.Data[0];
                    WriteVerbose(string.Format("Portal set to {0}", DnnPromptController.CurrentPortal.PortalName));
                }
            }
            WriteObject(DnnPromptController.CurrentPortal);
        }
    }
}

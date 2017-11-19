using Connect.DNN.Powershell.Framework;
using Connect.DNN.Powershell.Framework.Models;
using System.Management.Automation;

namespace Connect.DNN.Powershell.Commands.Portals
{
    [Cmdlet("List", "Portals")]
    public class ListPortals : DnnPromptCmdLet
    {
        protected override void ProcessRecord()
        {
            if (!FindSite()) { return; };
            WriteVerbose(string.Format("list-portals on {0}", CmdSite.Url));
            var response = DnnPromptController.ProcessCommand(CmdSite, 5, "list-portals");
            WriteVerbose(string.Format("Retrieved response {0}", response.Status));
            if (response.Status == ServerResponseStatus.Success)
            {
                var result = Newtonsoft.Json.JsonConvert.DeserializeObject<ConsoleResultModel<Models.PortalBase>>(response.Contents);
                WriteObject(result.Data);
            }
            else
            {
                WriteObject(response.Status);
            }
        }
    }
}

using Connect.DNN.Powershell.Framework;
using Connect.DNN.Powershell.Framework.Models;
using System.Management.Automation;

namespace Connect.DNN.Powershell.Commands.Roles
{
    [Cmdlet("List", "Roles")]
    public class ListRoles : DnnPromptCmdLet
    {
        [Parameter(Mandatory = false)]
        public int PortalId { get; set; } = -1;

        protected override void ProcessRecord()
        {
            if (!FindSite()) { return; };
            WriteVerbose(string.Format("list-roles on {0} portal {1}", CmdSite.Url, PortalId));
            var response = DnnPromptController.ProcessCommand(CmdSite, PortalId, 5, "list-roles");
            WriteVerbose(string.Format("Retrieved response {0}", response.Status));
            if (response.Status == ServerResponseStatus.Success)
            {
                var result = Newtonsoft.Json.JsonConvert.DeserializeObject<ConsoleResultModel<Models.RoleBase>>(response.Contents);
                WriteObject(result.Data);
            }
            else
            {
                WriteObject(response.Status);
            }
        }
    }
}

using Connect.DNN.Powershell.Core.Models;
using Connect.DNN.Powershell.Framework;
using Connect.DNN.Powershell.Framework.Models;

namespace Connect.DNN.Powershell.Core.Commands
{
    public class RoleCommands
    {
        public static RoleBase[] ListRoles(Data.Site site, int portalId)
        {
            var response = DnnPromptController.ProcessCommand(site, portalId, 5, "list-roles");
            var result = Newtonsoft.Json.JsonConvert.DeserializeObject<ConsoleResultModel<RoleBase>>(response.Contents);
            return result.Data;
        }
    }
}

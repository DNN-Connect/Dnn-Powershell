using Connect.DNN.Powershell.Common;
using Connect.DNN.Powershell.Core.Models;
using Connect.DNN.Powershell.Framework;
using Connect.DNN.Powershell.Framework.Models;

namespace Connect.DNN.Powershell.Core.Commands
{
    public class RoleCommands
    {
        public static string DeleteRole(Data.Site site, int portalId, int roleId)
        {
            var response = DnnPromptController.ProcessCommand(site, portalId, 5, string.Format("delete-role --id {0}", roleId));
            var result = Newtonsoft.Json.JsonConvert.DeserializeObject<ConsoleResultModel<object>>(response.Contents);
            result.AssertValidConsoleResponse();
            return result.Output;
        }
        public static RoleModel GetRole(Data.Site site, int portalId, int roleId)
        {
            var response = DnnPromptController.ProcessCommand(site, portalId, 5, string.Format("get-role --id {0}", roleId));
            var result = Newtonsoft.Json.JsonConvert.DeserializeObject<ConsoleResultModel<RoleModel>>(response.Contents);
            result.AssertValidConsoleResponse();
            return result.Data[0];
        }
        public static RoleModelBase[] ListRoles(Data.Site site, int portalId)
        {
            var response = DnnPromptController.ProcessCommand(site, portalId, 5, "list-roles");
            var result = Newtonsoft.Json.JsonConvert.DeserializeObject<ConsoleResultModel<RoleModelBase>>(response.Contents);
            result.AssertValidConsoleResponse();
            return result.Data;
        }
        public static RoleModel NewRole(Data.Site site, int portalId, string roleName, string description, bool? isPublic, bool? autoAssign, RoleStatus? status)
        {
            var cmd = string.Format("new-role --name {0}", roleName);
            cmd += string.IsNullOrEmpty(description) ? "" : string.Format(" --description {0}", description);
            cmd += isPublic == null ? "" : string.Format(" --public {0}", isPublic);
            cmd += autoAssign == null ? "" : string.Format(" --autoassign {0}", autoAssign);
            cmd += status == null ? "" : string.Format(" --status {0}", status.ToString().ToLower());
            var response = DnnPromptController.ProcessCommand(site, portalId, 5, cmd);
            var result = Newtonsoft.Json.JsonConvert.DeserializeObject<ConsoleResultModel<RoleModel>>(response.Contents);
            result.AssertValidConsoleResponse();
            return result.Data[0];
        }
        public static RoleModel SetRole(Data.Site site, int portalId, int roleId, string roleName, string description, bool? isPublic, bool? autoAssign, RoleStatus? status)
        {
            var cmd = string.Format("set-role --id {0}", roleId);
            cmd += string.IsNullOrEmpty(roleName) ? "" : string.Format(" --name {0}", roleName);
            cmd += string.IsNullOrEmpty(description) ? "" : string.Format(" --description {0}", description);
            cmd += isPublic == null ? "" : string.Format(" --public {0}", isPublic);
            cmd += autoAssign == null ? "" : string.Format(" --autoassign {0}", autoAssign);
            cmd += status == null ? "" : string.Format(" --status {0}", status.ToString().ToLower());
            var response = DnnPromptController.ProcessCommand(site, portalId, 5, cmd);
            var result = Newtonsoft.Json.JsonConvert.DeserializeObject<ConsoleResultModel<RoleModel>>(response.Contents);
            result.AssertValidConsoleResponse();
            return result.Data[0];
        }

        public enum RoleStatus
        {
            Pending = -1,
            Disabled = 0,
            Approved = 1
        }

    }
}

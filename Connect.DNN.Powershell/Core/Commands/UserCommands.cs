using Connect.DNN.Powershell.Common;
using Connect.DNN.Powershell.Core.Models;
using Connect.DNN.Powershell.Framework;
using Connect.DNN.Powershell.Framework.Models;
using System;

namespace Connect.DNN.Powershell.Core.Commands
{
    public class UserCommands
    {
        public static UserRoleModel[] AddRoles(Data.Site site, int portalId, int userId, string roles, System.DateTime? start, System.DateTime? end)
        {
            var cmd = string.Format("add-roles --id {0} --roles \"{1}\"", userId, roles);
            cmd += start == null ? "" : string.Format(" --start {0:yyyy-MM-dd}", start);
            cmd += end == null ? "" : string.Format(" --start {0:yyyy-MM-dd}", end);
            var response = DnnPromptController.ProcessCommand(site, portalId, 5, cmd);
            var result = Newtonsoft.Json.JsonConvert.DeserializeObject<ConsoleResultModel<UserRoleModel>>(response.Contents);
            result.AssertValidConsoleResponse();
            return result.Data;
        }
        public static UserModel DeleteUser(Data.Site site, int portalId, int userId, bool? notify)
        {
            var cmd = string.Format("delete-user --id {0}", userId);
            cmd += notify == null ? "" : string.Format(" --notify {0}", notify);
            var response = DnnPromptController.ProcessCommand(site, portalId, 5, cmd);
            var result = Newtonsoft.Json.JsonConvert.DeserializeObject<ConsoleResultModel<UserModel>>(response.Contents);
            result.AssertValidConsoleResponse();
            return result.Data[0];
        }
        public static UserModel GetUser(Data.Site site, int portalId, int? userId, string email, string username)
        {
            var cmd = string.Format("get-user");
            cmd += userId == null ? "" : string.Format(" --id {0}", userId);
            cmd += string.IsNullOrEmpty(email) ? "" : string.Format(" --email {0}", email);
            cmd += string.IsNullOrEmpty(username) ? "" : string.Format(" --username {0}", username);
            var response = DnnPromptController.ProcessCommand(site, portalId, 5, cmd);
            var result = Newtonsoft.Json.JsonConvert.DeserializeObject<ConsoleResultModel<UserModel>>(response.Contents);
            result.AssertValidConsoleResponse();
            return result.Data[0];
        }
        public static UserModelBase[] ListUsers(Data.Site site, int portalId, string email, string username, string role, int? page, int? max)
        {
            var cmd = string.Format("list-users");
            cmd += string.IsNullOrEmpty(email) ? "" : string.Format(" --email {0}", email);
            cmd += string.IsNullOrEmpty(username) ? "" : string.Format(" --username {0}", username);
            cmd += string.IsNullOrEmpty(role) ? "" : string.Format(" --role {0}", role);
            cmd += page == null ? "" : string.Format(" --page {0}", page);
            cmd += max == null ? "" : string.Format(" --max {0}", max);
            var response = DnnPromptController.ProcessCommand(site, portalId, 5, cmd);
            var result = Newtonsoft.Json.JsonConvert.DeserializeObject<ConsoleResultModel<UserModelBase>>(response.Contents);
            result.AssertValidConsoleResponse();
            return result.Data;
        }
        public static UserModel NewUser(Data.Site site, int portalId, string email, string username, string firstname, string lastname, string password, bool? approved, bool? notify)
        {
            var cmd = string.Format("new-user --email {0} --username {1} --firstname {2} --lastname {3}", email, username, firstname, lastname);
            cmd += string.IsNullOrEmpty(password) ? "" : string.Format(" --password {0}", password);
            cmd += approved == null ? "" : string.Format(" --approved {0}", approved);
            cmd += notify == null ? "" : string.Format(" --notify {0}", notify);
            var response = DnnPromptController.ProcessCommand(site, portalId, 5, cmd);
            var result = Newtonsoft.Json.JsonConvert.DeserializeObject<ConsoleResultModel<UserModel>>(response.Contents);
            result.AssertValidConsoleResponse();
            return result.Data[0];
        }
        public static string ResetPassword(Data.Site site, int portalId, int userId, bool? notify)
        {
            var cmd = string.Format("reset-password --id {0}", userId);
            cmd += notify == null ? "" : string.Format(" --notify {0}", notify);
            var response = DnnPromptController.ProcessCommand(site, portalId, 5, cmd);
            var result = Newtonsoft.Json.JsonConvert.DeserializeObject<ConsoleResultModel<object>>(response.Contents);
            result.AssertValidConsoleResponse();
            return result.Output;
        }
        public static UserModel SetUser(Data.Site site, int portalId, int userId, string email, string username, string displayname, string firstname, string lastname, string password, bool? approved)
        { 
            var cmd = string.Format("set-user --id {0}", userId);
            cmd += string.IsNullOrEmpty(email) ? "" : string.Format(" --email {0}", email);
            cmd += string.IsNullOrEmpty(username) ? "" : string.Format(" --username {0}", username);
            cmd += string.IsNullOrEmpty(displayname) ? "" : string.Format(" --displayname {0}", displayname);
            cmd += string.Format(" --firstname {0}", firstname);
            cmd += string.Format(" --lastname {0}", lastname);
            cmd += string.IsNullOrEmpty(password) ? "" : string.Format(" --password {0}", password);
            cmd += approved == null ? "" : string.Format(" --approved {0}", approved);
            var response = DnnPromptController.ProcessCommand(site, portalId, 5, cmd);
            var result = Newtonsoft.Json.JsonConvert.DeserializeObject<ConsoleResultModel<UserModel>>(response.Contents);
            result.AssertValidConsoleResponse();
            return result?.Data[0];
        }
    }
}

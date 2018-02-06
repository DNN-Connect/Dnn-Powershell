using Connect.DNN.Powershell.Common;
using Connect.DNN.Powershell.Framework;
using Connect.DNN.Powershell.Framework.Models;

namespace Connect.DNN.Powershell.Core.Commands
{
    public class RecyclebinCommands
    {
        public static string PurgeModule(Data.Site site, int portalId, int moduleId, int pageId)
        {
            var cmd = string.Format("purge-module --id {0} --pageid {1}", moduleId, pageId);
            var response = DnnPromptController.ProcessCommand(site, portalId, 5, cmd);
            var result = Newtonsoft.Json.JsonConvert.DeserializeObject<ConsoleResultModel<object>>(response.Contents);
            result.AssertValidConsoleResponse();
            return result.Output;
        }
        public static string PurgePage(Data.Site site, int portalId, int pageId, bool? deleteChildren)
        {
            var cmd = string.Format("purge-page --id {0}", pageId);
            cmd += deleteChildren == null ? "" : string.Format(" --deletechildren {0}", deleteChildren);
            var response = DnnPromptController.ProcessCommand(site, portalId, 5, cmd);
            var result = Newtonsoft.Json.JsonConvert.DeserializeObject<ConsoleResultModel<object>>(response.Contents);
            result.AssertValidConsoleResponse();
            return result.Output;
        }
        public static string PurgeUser(Data.Site site, int portalId, int userId)
        {
            var cmd = string.Format("purge-user --id {0}", userId);
            var response = DnnPromptController.ProcessCommand(site, portalId, 5, cmd);
            var result = Newtonsoft.Json.JsonConvert.DeserializeObject<ConsoleResultModel<object>>(response.Contents);
            result.AssertValidConsoleResponse();
            return result.Output;
        }
        public static string RestoreModule(Data.Site site, int portalId, int moduleId, int pageId)
        {
            var cmd = string.Format("restore-module --id {0} --pageid {1}", moduleId, pageId);
            var response = DnnPromptController.ProcessCommand(site, portalId, 5, cmd);
            var result = Newtonsoft.Json.JsonConvert.DeserializeObject<ConsoleResultModel<object>>(response.Contents);
            result.AssertValidConsoleResponse();
            return result.Output;
        }
        public static string RestorePage(Data.Site site, int portalId, int? pageId, string pageName, int? parentId)
        {
            var cmd = string.Format("restore-page");
            cmd += pageId == null ? "" : string.Format(" --id {0}", pageId);
            cmd += string.IsNullOrEmpty(pageName) ? "" : string.Format(" --pane {0}", pageName);
            cmd += parentId == null ? "" : string.Format(" --parentid {0}", parentId);
            var response = DnnPromptController.ProcessCommand(site, portalId, 5, cmd);
            var result = Newtonsoft.Json.JsonConvert.DeserializeObject<ConsoleResultModel<object>>(response.Contents);
            result.AssertValidConsoleResponse();
            return result.Output;
        }
        public static string RestoreUser(Data.Site site, int portalId, int userId)
        {
            var cmd = string.Format("restore-user --id {0}", userId);
            var response = DnnPromptController.ProcessCommand(site, portalId, 5, cmd);
            var result = Newtonsoft.Json.JsonConvert.DeserializeObject<ConsoleResultModel<object>>(response.Contents);
            result.AssertValidConsoleResponse();
            return result.Output;
        }
    }
}

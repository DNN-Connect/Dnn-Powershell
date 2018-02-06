using Connect.DNN.Powershell.Common;
using Connect.DNN.Powershell.Core.Models;
using Connect.DNN.Powershell.Framework;
using Connect.DNN.Powershell.Framework.Models;

namespace Connect.DNN.Powershell.Core.Commands
{
    public class ModuleCommands
    {
        public static ModuleInstanceModel[] AddModule(Data.Site site, int portalId, string moduleName, int pageId, string paneName, string moduleTitle)
        {
            var cmd = string.Format("add-module --name {0} --pageid {1}", moduleName, pageId);
            cmd += string.IsNullOrEmpty(paneName) ? "" : string.Format(" --pane {0}", paneName);
            cmd += string.IsNullOrEmpty(moduleTitle) ? "" : string.Format(" --title {0}", moduleTitle);
            var response = DnnPromptController.ProcessCommand(site, portalId, 5, cmd);
            var result = Newtonsoft.Json.JsonConvert.DeserializeObject<ConsoleResultModel<ModuleInstanceModel>>(response.Contents);
            result.AssertValidConsoleResponse();
            return result.Data;
        }
        public static ModuleInfoModel CopyModule(Data.Site site, int portalId, int moduleId, int pageId, int toPageId, string paneName, bool? includeSettings)
        {
            var cmd = string.Format("copy-module --id {0} --pageid {1} --topageid {2}", moduleId, pageId, toPageId);
            cmd += string.IsNullOrEmpty(paneName) ? "" : string.Format(" --pane {0}", paneName);
            cmd += includeSettings == null ? "" : string.Format(" --includesettings {0}", includeSettings);
            var response = DnnPromptController.ProcessCommand(site, portalId, 5, cmd);
            var result = Newtonsoft.Json.JsonConvert.DeserializeObject<ConsoleResultModel<ModuleInfoModel>>(response.Contents);
            result.AssertValidConsoleResponse();
            return result.Data[0];
        }
        public static string DeleteModule(Data.Site site, int portalId, int moduleId, int pageId)
        {
            var cmd = string.Format("copy-module --id {0} --pageid {1}", moduleId, pageId);
            var response = DnnPromptController.ProcessCommand(site, portalId, 5, cmd);
            var result = Newtonsoft.Json.JsonConvert.DeserializeObject<ConsoleResultModel<object>>(response.Contents);
            result.AssertValidConsoleResponse();
            return result.Output;
        }
        public static ModuleInfoModel GetModule(Data.Site site, int portalId, int moduleId, int pageId)
        {
            var cmd = string.Format("get-module --id {0} --pageid {1}", moduleId, pageId);
            var response = DnnPromptController.ProcessCommand(site, portalId, 5, cmd);
            var result = Newtonsoft.Json.JsonConvert.DeserializeObject<ConsoleResultModel<ModuleInfoModel>>(response.Contents);
            result.AssertValidConsoleResponse();
            return result.Data[0];
        }
        public static ModuleInfoModel[] ListModules(Data.Site site, int portalId, string moduleName, string moduleTitle, int? pageId, bool? deleted, int? page, int? max)
        {
            var cmd = string.Format("list-modules");
            cmd += string.IsNullOrEmpty(moduleName) ? "" : string.Format(" --name {0}", moduleName);
            cmd += string.IsNullOrEmpty(moduleTitle) ? "" : string.Format(" --title {0}", moduleTitle);
            cmd += pageId == null ? "" : string.Format(" --pageid {0}", pageId);
            cmd += deleted == null ? "" : string.Format(" --deleted {0}", deleted);
            cmd += page == null ? "" : string.Format(" --page {0}", page);
            cmd += max == null ? "" : string.Format(" --max {0}", max);
            var response = DnnPromptController.ProcessCommand(site, portalId, 5, cmd);
            var result = Newtonsoft.Json.JsonConvert.DeserializeObject<ConsoleResultModel<ModuleInfoModel>>(response.Contents);
            result.AssertValidConsoleResponse();
            return result.Data;
        }
        public static ModuleInfoModel MoveModule(Data.Site site, int portalId, int moduleId, int pageId, int toPageId, string paneName)
        {
            var cmd = string.Format("move-module --id {0} --pageid {1} --topageid {2}", moduleId, pageId, toPageId);
            cmd += string.IsNullOrEmpty(paneName) ? "" : string.Format(" --pane {0}", paneName);
            var response = DnnPromptController.ProcessCommand(site, portalId, 5, cmd);
            var result = Newtonsoft.Json.JsonConvert.DeserializeObject<ConsoleResultModel<ModuleInfoModel>>(response.Contents);
            result.AssertValidConsoleResponse();
            return result.Data[0];
        }

    }
}

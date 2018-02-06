using Connect.DNN.Powershell.Common;
using Connect.DNN.Powershell.Core.Models;
using Connect.DNN.Powershell.Framework;
using Connect.DNN.Powershell.Framework.Models;

namespace Connect.DNN.Powershell.Core.Commands
{
    public class PageCommands
    {
        public static string DeletePage(Data.Site site, int portalId, int? pageId, string pageName, int? parentId)
        {
            var cmd = string.Format("delete-page");
            cmd += pageId == null ? "" : string.Format(" --id {0}", pageId);
            cmd += string.IsNullOrEmpty(pageName) ? "" : string.Format(" --name {0}", pageName);
            cmd += parentId == null ? "" : string.Format(" --parentid {0}", parentId);
            var response = DnnPromptController.ProcessCommand(site, portalId, 5, cmd);
            var result = Newtonsoft.Json.JsonConvert.DeserializeObject<ConsoleResultModel<object>>(response.Contents);
            result.AssertValidConsoleResponse();
            return result.Output;
        }
        public static PageModel GetPage(Data.Site site, int portalId, int? pageId, string pageName, int? parentId)
        {
            var cmd = string.Format("get-page");
            cmd += pageId == null ? "" : string.Format(" --id {0}", pageId);
            cmd += string.IsNullOrEmpty(pageName) ? "" : string.Format(" --name {0}", pageName);
            cmd += parentId == null ? "" : string.Format(" --parentid {0}", parentId);
            var response = DnnPromptController.ProcessCommand(site, portalId, 5, cmd);
            var result = Newtonsoft.Json.JsonConvert.DeserializeObject<ConsoleResultModel<PageModel>>(response.Contents);
            result.AssertValidConsoleResponse();
            return result.Data[0];
        }
        public static string GetPageUrl(Data.Site site, int portalId, int? pageId, string pageName, int? parentId)
        {
            var cmd = string.Format("goto");
            cmd += pageId == null ? "" : string.Format(" --id {0}", pageId);
            cmd += string.IsNullOrEmpty(pageName) ? "" : string.Format(" --name {0}", pageName);
            cmd += parentId == null ? "" : string.Format(" --parentid {0}", parentId);
            var response = DnnPromptController.ProcessCommand(site, portalId, 5, cmd);
            var result = Newtonsoft.Json.JsonConvert.DeserializeObject<ConsoleResultModel<object>>(response.Contents);
            result.AssertValidConsoleResponse();
            return result.Output;
        }
        public static PageModelBase[] ListPages(Data.Site site, int portalId, int? parentId, bool? deleted, string pageName, string pageTitle, string path, string skin, bool? visible, int? page, int? max)
        {
            var cmd = string.Format("list-pages");
            cmd += parentId == null ? "" : string.Format(" --parentid {0}", parentId);
            cmd += deleted == null ? "" : string.Format(" --deleted {0}", deleted);
            cmd += string.IsNullOrEmpty(pageName) ? "" : string.Format(" --name {0}", pageName);
            cmd += string.IsNullOrEmpty(pageTitle) ? "" : string.Format(" --title {0}", pageTitle);
            cmd += string.IsNullOrEmpty(path) ? "" : string.Format(" --path {0}", path);
            cmd += string.IsNullOrEmpty(skin) ? "" : string.Format(" --skin {0}", skin);
            cmd += visible == null ? "" : string.Format(" --visible {0}", visible);
            cmd += page == null ? "" : string.Format(" --page {0}", page);
            cmd += max == null ? "" : string.Format(" --max {0}", max);
            var response = DnnPromptController.ProcessCommand(site, portalId, 5, cmd);
            var result = Newtonsoft.Json.JsonConvert.DeserializeObject<ConsoleResultModel<PageModelBase>>(response.Contents);
            result.AssertValidConsoleResponse();
            return result.Data;
        }
        public static PageModel NewPage(Data.Site site, int portalId, int? parentId, string pageTitle, string pageName, string url, string description, string keywords, bool? visible)
        {
            var cmd = string.Format("new-page --name {0}", pageName);
            cmd += parentId == null ? "" : string.Format(" --parentid {0}", parentId);
            cmd += string.IsNullOrEmpty(pageTitle) ? "" : string.Format(" --title {0}", pageTitle);
            cmd += string.IsNullOrEmpty(url) ? "" : string.Format(" --url {0}", url);
            cmd += string.IsNullOrEmpty(description) ? "" : string.Format(" --description {0}", description);
            cmd += string.IsNullOrEmpty(keywords) ? "" : string.Format(" --keywords {0}", keywords);
            cmd += visible == null ? "" : string.Format(" --visible {0}", visible);
            var response = DnnPromptController.ProcessCommand(site, portalId, 5, cmd);
            var result = Newtonsoft.Json.JsonConvert.DeserializeObject<ConsoleResultModel<PageModel>>(response.Contents);
            result.AssertValidConsoleResponse();
            return result.Data[0];
        }
        public static PageModel SetPage(Data.Site site, int portalId, int pageId, int? parentId, string pageTitle, string pageName, string url, string description, string keywords, bool? visible)
        {
            var cmd = string.Format("set-page --id {0}", pageId);
            cmd += parentId == null ? "" : string.Format(" --parentid {0}", parentId);
            cmd += string.IsNullOrEmpty(pageTitle) ? "" : string.Format(" --title {0}", pageTitle);
            cmd += string.IsNullOrEmpty(url) ? "" : string.Format(" --url {0}", url);
            cmd += string.IsNullOrEmpty(description) ? "" : string.Format(" --description {0}", description);
            cmd += string.IsNullOrEmpty(keywords) ? "" : string.Format(" --keywords {0}", keywords);
            cmd += visible == null ? "" : string.Format(" --visible {0}", visible);
            var response = DnnPromptController.ProcessCommand(site, portalId, 5, cmd);
            var result = Newtonsoft.Json.JsonConvert.DeserializeObject<ConsoleResultModel<PageModel>>(response.Contents);
            result.AssertValidConsoleResponse();
            return result.Data[0];
        }
    }
}

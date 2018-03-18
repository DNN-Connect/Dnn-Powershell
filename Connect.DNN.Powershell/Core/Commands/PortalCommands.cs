using Connect.DNN.Powershell.Common;
using Connect.DNN.Powershell.Core.Models;
using Connect.DNN.Powershell.Framework;
using Connect.DNN.Powershell.Framework.Models;

namespace Connect.DNN.Powershell.Core.Commands
{
    public class PortalCommands
    {
        public static Portal GetPortal(Data.Site site)
        {
            return GetPortal(site, -1);
        }
        public static Portal GetPortal(Data.Site site, int portalId)
        {
            var cmd = portalId == -1 ? "get-portal" : string.Format("get-portal --id {0}", portalId);
            var response = DnnPromptController.ProcessCommand(site, 5, cmd);
            var result = Newtonsoft.Json.JsonConvert.DeserializeObject<ConsoleResultModel<Portal>>(response.Contents);
            result.AssertValidConsoleResponse();
            return result.Data[0];
        }
        public static PortalBase[] ListPortals(Data.Site site)
        {
            var response = DnnPromptController.ProcessCommand(site, 5, "list-portals");
            var result = Newtonsoft.Json.JsonConvert.DeserializeObject<ConsoleResultModel<PortalBase>>(response.Contents);
            result.AssertValidConsoleResponse();
            return result.Data;
        }
        public static Portal ClearLog(Data.Site site)
        {
            return ClearLog(site, -1);
        }
        public static Portal ClearLog(Data.Site site, int portalId)
        {
            var response = DnnPromptController.ProcessCommand(site, portalId, 5, "get-portal");
            var result = Newtonsoft.Json.JsonConvert.DeserializeObject<ConsoleResultModel<Portal>>(response.Contents);
            result.AssertValidConsoleResponse();
            return result.Data[0];
        }
    }
}

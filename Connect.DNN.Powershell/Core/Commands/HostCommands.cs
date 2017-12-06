using Connect.DNN.Powershell.Core.Models;
using Connect.DNN.Powershell.Framework;
using Connect.DNN.Powershell.Framework.Models;

namespace Connect.DNN.Powershell.Core.Commands
{
   public class HostCommands
    {
        public static bool ClearCache(Data.Site site)
        {
            var response = DnnPromptController.ProcessCommand(site, 5, "clear-cache");
            return response.Status == ServerResponseStatus.Success;
        }
        public static HostModel GetHost(Data.Site site)
        {
            var response = DnnPromptController.ProcessCommand(site, 5, "get-host");
            var result = Newtonsoft.Json.JsonConvert.DeserializeObject<ConsoleResultModel<HostModel>>(response.Contents);
            return result.Data[0];
        }
    }
}

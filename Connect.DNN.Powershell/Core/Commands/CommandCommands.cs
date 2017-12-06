using Connect.DNN.Powershell.Core.Models;
using Connect.DNN.Powershell.Framework;
using Connect.DNN.Powershell.Framework.Models;

namespace Connect.DNN.Powershell.Core.Commands
{
   public class CommandCommands
    {
        public static Command[] ListCommands(Data.Site site)
        {
            var response = DnnPromptController.ProcessCommand(site, 5, "list-commands");
            var result = Newtonsoft.Json.JsonConvert.DeserializeObject<ConsoleResultModel<Command>>(response.Contents);
            return result.Data;
        }
    }
}

using Connect.DNN.Powershell.Framework;

namespace Connect.DNN.Powershell.Core.Commands
{
    public class ApplicationCommands
    {
        public static bool RestartApplication(Data.Site site)
        {
            var response = DnnPromptController.ProcessCommand(site, 5, "restart-application");
            return response.Status == ServerResponseStatus.Success;
        }
    }
}

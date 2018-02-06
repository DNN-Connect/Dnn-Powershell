using Connect.DNN.Powershell.Common;
using Connect.DNN.Powershell.Core.Models;
using Connect.DNN.Powershell.Framework;
using Connect.DNN.Powershell.Framework.Models;

namespace Connect.DNN.Powershell.Core.Commands
{
    public class TaskSchedulerCommands
    {
        public static TaskModel GetTask(Data.Site site, int portalId, int taskId)
        {
            var cmd = string.Format("get-task --id {0}", taskId);
            var response = DnnPromptController.ProcessCommand(site, portalId, 5, cmd);
            var result = Newtonsoft.Json.JsonConvert.DeserializeObject<ConsoleResultModel<TaskModel>>(response.Contents);
            result.AssertValidConsoleResponse();
            return result.Data[0];
        }
        public static TaskModelBase[] ListTasks(Data.Site site, int portalId, bool? enabled, string taskName)
        {
            var cmd = string.Format("list-tasks");
            cmd += enabled == null ? "" : string.Format(" --enabled {0}", enabled);
            cmd += string.IsNullOrEmpty(taskName) ? "" : string.Format(" --name {0}", taskName);
            var response = DnnPromptController.ProcessCommand(site, portalId, 5, cmd);
            var result = Newtonsoft.Json.JsonConvert.DeserializeObject<ConsoleResultModel<TaskModelBase>>(response.Contents);
            result.AssertValidConsoleResponse();
            return result.Data;
        }
        public static TaskModel SetTask(Data.Site site, int portalId, int taskId, bool enabled)
        {
            var cmd = string.Format("set-task --id {0} --enabled {1}", taskId, enabled);
            var response = DnnPromptController.ProcessCommand(site, portalId, 5, cmd);
            var result = Newtonsoft.Json.JsonConvert.DeserializeObject<ConsoleResultModel<TaskModel>>(response.Contents);
            result.AssertValidConsoleResponse();
            return result.Data[0];
        }
    }
}

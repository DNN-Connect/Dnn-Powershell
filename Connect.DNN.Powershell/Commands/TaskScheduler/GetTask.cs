using Connect.DNN.Powershell.Core.Commands;
using Connect.DNN.Powershell.Framework.Models;
using System.Management.Automation;

namespace Connect.DNN.Powershell.Commands.TaskScheduler
{
    [Cmdlet("Get", "Task")]
    public class GetTask : DnnPromptPortalCmdLet
    {
        [Parameter(Mandatory = true)]
        public int TaskId { get; set; }

        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            if (CmdSite == null || CmdPortal == null) { return; };
            WriteVerbose(string.Format("get-task on {0} portal {1}", CmdSite.Url, CmdPortal.PortalId));
            var response = TaskSchedulerCommands.GetTask(CmdSite, CmdPortal.PortalId, TaskId);
            WriteObject(response);
        }
    }
}

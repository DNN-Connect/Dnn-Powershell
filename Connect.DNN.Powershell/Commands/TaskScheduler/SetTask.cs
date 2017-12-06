using Connect.DNN.Powershell.Core.Commands;
using Connect.DNN.Powershell.Framework.Models;
using System.Management.Automation;

namespace Connect.DNN.Powershell.Commands.TaskScheduler
{
    [Cmdlet("Set", "Task")]
    public class SetTask : DnnPromptPortalCmdLet
    {
        [Parameter(Mandatory = true)]
        public int TaskId { get; set; }

        [Parameter(Mandatory = true)]
        public bool Enabled { get; set; }

        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            if (CmdSite == null || CmdPortal == null) { return; };
            WriteVerbose(string.Format("set-task on {0} portal {1}", CmdSite.Url, CmdPortal.PortalId));
            var response = TaskSchedulerCommands.SetTask(CmdSite, CmdPortal.PortalId, TaskId, Enabled);
            WriteObject(response);
        }
    }
}

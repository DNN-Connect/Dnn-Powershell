using Connect.DNN.Powershell.Core.Commands;
using Connect.DNN.Powershell.Framework.Models;
using System.Management.Automation;

namespace Connect.DNN.Powershell.Commands.TaskScheduler
{
    [Cmdlet("List", "Tasks")]
    public class ListTasks : DnnPromptPortalCmdLet
    {
        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true)]
        public bool? Enabled { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true)]
        public string TaskName { get; set; }

        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            if (CmdSite == null || CmdPortal == null) { return; };
            WriteVerbose(string.Format("list-tasks on {0} portal {1}", CmdSite.Url, CmdPortal.PortalId));
            var response = TaskSchedulerCommands.ListTasks(CmdSite, CmdPortal.PortalId, Enabled, TaskName);
            WriteArray(response);
        }
    }
}

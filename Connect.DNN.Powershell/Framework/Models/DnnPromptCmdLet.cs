using Connect.DNN.Powershell.Data;
using System.Management.Automation;

namespace Connect.DNN.Powershell.Framework.Models
{
    public class DnnPromptCmdLet : PSCmdlet
    {

        [Parameter(Mandatory = false)]
        public string Key { get; set; }

        protected Site CmdSite { get; private set; }

        protected override void ProcessRecord()
        {
            CmdSite = DnnPromptController.CurrentSite;
            if (!string.IsNullOrEmpty(Key))
            {
                try
                {
                    CmdSite = SiteList.Instance().Sites[Key];
                }
                catch
                {
                }
            }
            if (CmdSite == null)
            {
                WriteWarning("No site has been defined");
            }
        }
    }
}

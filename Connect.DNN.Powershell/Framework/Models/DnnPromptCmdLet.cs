using Connect.DNN.Powershell.Common;
using Connect.DNN.Powershell.Data;
using System.Management.Automation;
using System.Security;

namespace Connect.DNN.Powershell.Framework.Models
{
    public class DnnPromptCmdLet : BaseCmdLet
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
                return;
            }
            if (System.DateTime.Now.AddHours(1) > CmdSite.Expires)
            {
                CheckSite(CmdSite, Key);
            }
        }
    }
}

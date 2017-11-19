using Connect.DNN.Powershell.Data;
using System.Management.Automation;

namespace Connect.DNN.Powershell.Framework.Models
{
    public class DnnPromptCmdLet : PSCmdlet
    {

        [Parameter(Position = 0, Mandatory = false)]
        public string Key { get; set; }

        protected Site CmdSite { get; private set; }

        protected bool FindSite()
        {
            if (string.IsNullOrEmpty(Key))
            {
                CmdSite = DnnPromptController.CurrentSite;
            }
            else
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
                return false;
            }
            return true;
        }
    }
}

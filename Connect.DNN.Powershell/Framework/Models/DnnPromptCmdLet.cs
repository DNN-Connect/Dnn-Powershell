using System.Management.Automation;

namespace Connect.DNN.Powershell.Framework.Models
{
    public class DnnPromptCmdLet : PSCmdlet
    {

        [Parameter(Position = 0, Mandatory = false)]
        public string Key { get; set; }

        protected bool ParseKey()
        {
            if (string.IsNullOrEmpty(Key))
            {
                Key = DnnPromptController.CurrentSiteKey;
            }
            if (string.IsNullOrEmpty(Key))
            {
                WriteWarning("No site has been defined");
                return false;
            }
            return true;
        }
    }
}

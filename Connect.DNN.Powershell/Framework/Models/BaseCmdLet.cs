using Connect.DNN.Powershell.Common;
using Connect.DNN.Powershell.Data;
using System.Management.Automation;
using System.Security;

namespace Connect.DNN.Powershell.Framework.Models
{
    public class BaseCmdLet : PSCmdlet
    {
        public ServerResponseStatus CheckSite(Site site, string key)
        {
            var result = DnnPromptController.ProcessCommand(site, 5, "echo Hello World");
            var retries = 3;
            while (retries > 0 && result.Status == ServerResponseStatus.Failed)
            {
                WriteWarning("Login failed. Please provide username and password again.");
                var creds = GetLogin();
                result = DnnPromptController.GetToken(site.Url, creds.Username, creds.Password.ToUnsecureString());
                if (result.Status == ServerResponseStatus.Success)
                {
                    var sites = SiteList.Instance();
                    sites.SetSite(key, site.Url, result.Contents, true);
                }
                retries--;
            }
            return result.Status;
        }

        public class Credentials
        {
            public string Username { get; set; }
            public SecureString Password { get; set; }
        }
        public Credentials GetLogin()
        {
            var res = InvokeCommand.InvokeScript("Read-Host -Prompt 'Username'");
            var username = (string)res[0].BaseObject;
            res = InvokeCommand.InvokeScript("Read-Host -Prompt 'Password' -assecurestring");
            var password = (SecureString)res[0].BaseObject;
            return new Credentials() { Username = username, Password = password };
        }

        public void WriteArray(object[] response)
        {
            foreach (var obj in response )
            {
                WriteObject(obj);
            }
        }
    }
}

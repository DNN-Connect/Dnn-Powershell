using Connect.DNN.Powershell.Common;
using Connect.DNN.Powershell.Data;
using Connect.DNN.Powershell.Framework.Models;
using System.IO;
using System.Net;

namespace Connect.DNN.Powershell.Framework
{
    public class DnnPromptController
    {
        public static ServerResponse GetToken(string siteKey, string siteUrl, string username, string password)
        {
            var url = string.Format("{0}/DesktopModules/JwtAuth/API/mobile/login", siteUrl);
            var request = WebRequest.Create(url);
            request.ContentType = "application/json; charset=utf-8";
            request.Method = WebRequestMethods.Http.Post;
            using (var streamWriter = new StreamWriter(request.GetRequestStream()))
            {
                string json = "{\"u\":\"" + username + "\"," +
                              "\"p\":\"" + password + "\"}";
                streamWriter.Write(json);
                streamWriter.Flush();
                streamWriter.Close();
            }
            string tokenText;
            try
            {
                var response = (HttpWebResponse)request.GetResponse();
                using (var sr = new StreamReader(response.GetResponseStream()))
                {
                    tokenText = sr.ReadToEnd();
                }
                var sites = SiteList.Instance();
                sites.SetSite(siteKey, siteUrl, tokenText);
                return ServerResponse.Success;
            }
            catch (WebException ex)
            {
                switch (((HttpWebResponse)ex.Response).StatusCode)
                {
                    case HttpStatusCode.Unauthorized:
                        return ServerResponse.Failed;
                    default:
                        return ServerResponse.Error;
                }
            }
        }

        public static ServerResponse RenewToken(string siteKey)
        {
            var sites = SiteList.Instance();
            var site = sites.Sites[siteKey];
            var token = Newtonsoft.Json.JsonConvert.DeserializeObject<JwtToken>(site.Token.Decrypt());
            var url = string.Format("{0}/DesktopModules/JwtAuth/API/mobile/extendtoken", site.Url);
            var request = WebRequest.Create(url);
            request.ContentType = "application/json; charset=utf-8";
            request.Method = WebRequestMethods.Http.Post;
            request.Headers.Add("Authorization", "Bearer " + token.accessToken);
            using (var streamWriter = new StreamWriter(request.GetRequestStream()))
            {
                string json = "{\"rtoken\":\"" + token.renewalToken + "\"}";
                streamWriter.Write(json);
                streamWriter.Flush();
                streamWriter.Close();
            }
            string tokenText;
            try
            {
                var response = (HttpWebResponse)request.GetResponse();
                using (var sr = new StreamReader(response.GetResponseStream()))
                {
                    tokenText = sr.ReadToEnd();
                }
                sites.SetSite(siteKey, site.Url, tokenText);
                return ServerResponse.Success;
            }
            catch (WebException ex)
            {
                switch (((HttpWebResponse)ex.Response).StatusCode)
                {
                    case HttpStatusCode.Unauthorized:
                        return ServerResponse.Failed;
                    default:
                        return ServerResponse.Error;
                }
            }
        }

        public static CommandResult ProcessCommand(string siteKey, int retry, string commandLine)
        {
            return ProcessCommand(siteKey, retry, commandLine, -1);
        }
        public static CommandResult ProcessCommand(string siteKey, int retry, string commandLine, int currentPage)
        {
            var res = new CommandResult();
            if (retry == 0)
            {
                res.Status = ServerResponse.Error;
                return res;
            }
            var sites = SiteList.Instance();
            var site = sites.Sites[siteKey];
            var token = Newtonsoft.Json.JsonConvert.DeserializeObject<JwtToken>(site.Token.Decrypt());
            var promptUrl = string.Format("{0}/API/PersonaBar/Command/Cmd", site.Url);
            var request = WebRequest.Create(promptUrl);
            request.ContentType = "application/json; charset=utf-8";
            request.Method = WebRequestMethods.Http.Post;
            request.Headers.Add("Authorization", "Bearer " + token.accessToken);
            var reqCmd = new PromptCommand() {
                CmdLine = commandLine,
                CurrentPage = currentPage
            };
            using (var streamWriter = new StreamWriter(request.GetRequestStream()))
            {
                string json = Newtonsoft.Json.JsonConvert.SerializeObject(reqCmd);
                streamWriter.Write(json);
                streamWriter.Flush();
                streamWriter.Close();
            }
            try
            {
                var response = (HttpWebResponse)request.GetResponse();
                using (var sr = new StreamReader(response.GetResponseStream()))
                {
                    res.Contents = sr.ReadToEnd();
                }
                return res;
            }
            catch (WebException ex)
            {
                switch (((HttpWebResponse)ex.Response).StatusCode)
                {
                    case HttpStatusCode.Unauthorized:
                        var renew = RenewToken(siteKey);
                        if (renew != ServerResponse.Success)
                        {
                            res.Status = renew;
                            return res;
                        }
                        return ProcessCommand(siteKey, retry - 1, commandLine);
                    default:
                        res.Status = ServerResponse.Error;
                        return res;
                }
            }
        }
    }
}

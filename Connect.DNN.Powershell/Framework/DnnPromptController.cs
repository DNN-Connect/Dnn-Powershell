using Connect.DNN.Powershell.Data;
using Connect.DNN.Powershell.Framework.Models;
using System.IO;
using System.Net;

namespace Connect.DNN.Powershell.Framework
{
    public class DnnPromptController
    {
        public static JwtToken GetToken(string siteUrl, string username, string password)
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
            var response = (HttpWebResponse)request.GetResponse();
            using (var sr = new StreamReader(response.GetResponseStream()))
            {
                tokenText = sr.ReadToEnd();
            }
            return Newtonsoft.Json.JsonConvert.DeserializeObject<JwtToken>(tokenText);
        }

        public static string ProcessCommand(string siteKey, string command)
        {
            var sites = SiteList.Instance();
            var site = sites.Sites[siteKey];
            var token = Newtonsoft.Json.JsonConvert.DeserializeObject<JwtToken>(site.Token);
            var promptUrl = string.Format("{0}/API/PersonaBar/Command/Cmd", site.Url);
            var request = WebRequest.Create(promptUrl);
            request.ContentType = "application/json; charset=utf-8";
            request.Method = WebRequestMethods.Http.Post;
            request.Headers.Add("Authorization", "Bearer " + token.accessToken);
            using (var streamWriter = new StreamWriter(request.GetRequestStream()))
            {
                string json = "{\"cmdLine\":\"" + command + "\"," +
                              "\"currentPage\":\"20\"}";

                streamWriter.Write(json);
                streamWriter.Flush();
                streamWriter.Close();
            }
            var response = (HttpWebResponse)request.GetResponse();
            var responseText = "";
            using (var sr = new StreamReader(response.GetResponseStream()))
            {
                responseText = sr.ReadToEnd();
            }
            return responseText;
        }
    }
}

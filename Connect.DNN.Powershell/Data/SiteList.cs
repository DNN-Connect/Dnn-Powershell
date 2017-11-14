using Connect.DNN.Powershell.Common;
using Connect.DNN.Powershell.Framework.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;

namespace Connect.DNN.Powershell.Data
{
    public class SiteList
    {
        private static SiteList instance { get; set; }

        [JsonIgnore]
        public string FilePath { get; set; }

        [JsonProperty(PropertyName = "sites")]
        public Dictionary<string, Site> Sites { get; set; } = new Dictionary<string, Site>();

        public static SiteList Instance()
        {
            if (instance == null)
            {
                string codeBase = Assembly.GetExecutingAssembly().CodeBase;
                UriBuilder uri = new UriBuilder(codeBase);
                string path = Uri.UnescapeDataString(uri.Path);
                var file = Path.Combine(Path.GetDirectoryName(path), "Sites.json");
                if (File.Exists(file))
                {
                    try
                    {
                        instance = JsonConvert.DeserializeObject<SiteList>(Globals.ReadFile(file));
                    }
                    catch (Exception)
                    {
                        throw new Exception("Cannot read existing Sites.json file");
                    }
                }
                if (instance == null)
                {
                    instance = new SiteList();
                }
                instance.FilePath = file;
            }
            return instance;
        }

        public void SetSite(string key, string url, JwtToken token)
        {
            var s = new Site()
            {
                Url = url,
                Token = JsonConvert.SerializeObject(token).Encrypt()
            };
            Sites[key] = s;
            Globals.SaveString(FilePath, JsonConvert.SerializeObject(this));
        }
        public void SetSite(string key, string url, string token)
        {
            var s = new Site()
            {
                Url = url,
                Token = token.Encrypt()
            };
            Sites[key] = s;
            Globals.SaveString(FilePath, JsonConvert.SerializeObject(this));
        }
    }
}

using Newtonsoft.Json;

namespace Connect.DNN.Powershell.Data
{
    public class Site
    {
        [JsonProperty(PropertyName = "url")]
        public string Url { get; set; }
        [JsonProperty(PropertyName = "token")]
        public string Token { get; set; }
    }
}

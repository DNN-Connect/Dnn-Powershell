using Newtonsoft.Json;
using System.Collections.Generic;

namespace Connect.DNN.Powershell.Data
{
    public class Site
    {
        [JsonProperty(PropertyName = "url")]
        public string Url { get; set; }
        [JsonProperty(PropertyName = "token")]
        public string Token { get; set; }
        [JsonProperty(PropertyName = "expires")]
        public System.DateTime Expires { get; set; }
        [JsonIgnore]
        public int PortalId { get; set; }
        [JsonIgnore]
        public Dictionary<int, Portal> Portals { get; set; } = new Dictionary<int, Portal>();
    }
}

using Newtonsoft.Json;

namespace Connect.DNN.Powershell.Framework.Models
{
   public class PromptCommand
    {
        [JsonProperty(PropertyName = "cmdLine")]
        public string CmdLine { get; set; }
        [JsonProperty(PropertyName = "currentPage")]
        public int CurrentPage { get; set; }
    }
}

using Newtonsoft.Json;

namespace Connect.DNN.Powershell.Framework.Models
{
    public class ConsoleResultModel<T>
    {
        // the returned result - text or HTML
        [JsonProperty(PropertyName = "output")]
        public string Output;
        // is the output an error message?
        [JsonProperty(PropertyName = "isError")]
        public bool IsError;
        // is the Output HTML?
        [JsonProperty(PropertyName = "isHtml")]
        public bool IsHtml;
        // should the client reload after processing the command
        [JsonProperty(PropertyName = "mustReload")]
        public bool MustReload;
        // the response contains data to be formatted by the client
        [JsonProperty(PropertyName = "data")]
        public T[] Data;
        // optionally tell the client in what order the fields should be displayed
        [JsonProperty(PropertyName = "fieldOrder")]
        public string[] FieldOrder;

        [JsonProperty(PropertyName = "pagingInfo")]
        public PagingInfo PagingInfo;

        [JsonProperty(PropertyName = "nextPageCommand")]
        public string NextPageCommand;


        [JsonProperty(PropertyName = "records")]
        public int Records { get; set; }
    }
}

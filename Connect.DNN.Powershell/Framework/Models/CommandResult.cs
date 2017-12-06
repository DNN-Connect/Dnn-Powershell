namespace Connect.DNN.Powershell.Framework.Models
{
    public class ServerResponse
    {
        public ServerResponseStatus Status { get; set; } = ServerResponseStatus.Success;
        public string Contents { get; set; } = "";
    }
}

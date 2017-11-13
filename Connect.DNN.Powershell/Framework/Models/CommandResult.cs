namespace Connect.DNN.Powershell.Framework.Models
{
    public class CommandResult
    {
        public ServerResponse Status { get; set; } = ServerResponse.Success;
        public string Contents { get; set; } = "";
    }
}

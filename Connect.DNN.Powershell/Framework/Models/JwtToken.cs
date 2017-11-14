namespace Connect.DNN.Powershell.Framework.Models
{
    public class JwtToken
    {
        public int userId { get; set; }
        public string displayName { get; set; }
        public string accessToken { get; set; }
        public string renewalToken { get; set; }
    }
}

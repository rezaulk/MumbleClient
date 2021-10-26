

namespace Sentra.PTT.Utility.Models
{
    public class TokenServerConfig
    {
        public string Server { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string ClientSecretUserName { get; set; }
        public string ClientSecretPassword { get; set; }
        public bool CheckToken { get; set; } = true;
    }
}

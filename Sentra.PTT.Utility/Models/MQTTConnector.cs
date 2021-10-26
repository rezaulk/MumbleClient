

namespace Sentra.PTT.Utility.Models
{
    public class MQTTConnector
    {
        public string BrokerClientHost { get; set; }
        public string BrokerHost { get; set; }
        public int BrokerPort { get; set; }
        public bool IsSecure { get; set; }
        public string UserID { get; set; }
        public string Password { get; set; }
    }
}

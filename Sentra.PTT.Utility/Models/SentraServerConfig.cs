

namespace Sentra.PTT.Utility.Models
{
    public class SentraServerConfig
    {
        public string ClientAddress { get; set; }
        public string Address { get; set; }
        public int Port { get; set; }
        public int ClientPort { get; set; }
        public string Secret { get; set; }
        public string CallbackAddress { get; set; }
        public int CallbackPort { get; set; }
    }
}

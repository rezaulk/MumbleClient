using System;

namespace Sentra.PTT.Utility.Models
{
    public class LocationListeningMessage
    {
        public int SentraChannelID { get; set; }
        public int SentraUserID { get; set; }
        public int CompanyID { get; set; }
        public string DateTime { get; set; }
        public Object Object { get; set; }
    }
}

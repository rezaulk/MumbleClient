

namespace Sentra.PTT.Utility.Models
{
    public class RemoveUserFromChannel
    {
        public int CompanyID { get; set; } = 0;
        public int RemoveUserID { get; set; }
        public int OtherPartyID { get; set; }
        public int ChannelID { get; set; }
        public string ChannelName { get; set; }
        public bool IsSelf { get; set; } = false;
    }
}

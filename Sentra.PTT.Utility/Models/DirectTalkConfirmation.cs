

namespace Sentra.PTT.Utility.Models
{
    public class DirectTalkConfirmation
    {
        public int CompanyID { get; set; } = 0;
        public int CallerID { get; set; }
        public int CalleeID { get; set; }
        public int PickType { get; set; }
        public int ChannelID { get; set; }
    }
}

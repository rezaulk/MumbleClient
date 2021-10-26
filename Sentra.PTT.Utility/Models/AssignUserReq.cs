

namespace Sentra.PTT.Utility.Models
{
    public class AssignUserReq
    {
        public int SentraChannelID { get; set; }
        public int SentraUserID { get; set; }
        public bool NeedToMute { get; set; } = false;
        public bool NeedToDeaf { get; set; } = false;
    }
}

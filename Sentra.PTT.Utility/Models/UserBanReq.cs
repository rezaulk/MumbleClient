

namespace Sentra.PTT.Utility.Models
{
    public class UserBanReq
    {
        public int BanUserID { get; set; }
        public int SelfUserID { get; set; }
        public int CompanyID { get; set; } = 0;
    }
}

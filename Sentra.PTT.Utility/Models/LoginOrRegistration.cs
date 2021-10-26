

namespace Sentra.PTT.Utility.Models
{
    public class LoginOrRegistration
    {
        public string MobileNo { get; set; }
        public string Email { get; set; }
        public string FullName { get; set; }


        public string DeviceUniqueID { set; get; }
        public string VarificationCode { set; get; }
        public bool IsVerificationNeed { set; get; } = true;
        public string Password { get; set; }
        public string channelName { get; set; }


    }
}

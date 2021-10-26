
namespace Sentra.PTT.Utility.Models
{
    public class QRCodeToAddUser
    {
        public string Email { get; set; }
        public int CompanyID { get; set; } = 0;
        public int UserID { get; set; }
        public string Token { get; set; }
    }
}

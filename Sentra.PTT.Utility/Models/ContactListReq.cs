using System.Collections.Generic;

namespace Sentra.PTT.Utility.Models
{
    public class ContactListReq
    {
        public List<string> lstPhoneNo { get; set; } = new List<string>();
        public int UserID { get; set; }
        public string Password { get; set; }
        public bool IsFreeUser { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace Sentra.PTT.Utility.Models
{
    public class ConfirmRegistration
    {
        public string MobileNo { get; set; }
        public string UserName { set; get; }
        public string Password { set; get; }
        public string Token { set; get; }
        public string UserDisplayName { set; get; }
    }
}

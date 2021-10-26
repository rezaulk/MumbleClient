using System;
using System.Collections.Generic;
using System.Text;

namespace Sentra.PTT.Utility.Models
{
    public class UserRequestModel
    {
        public int UserID { get; set; }
        public string Name { get; set; }
        public string Password { get; set; }
        public string Email { get; set; } = "";
        public string Comment { get; set; } = "";
        public int ServerID { get; set; } = 1;
    }
}

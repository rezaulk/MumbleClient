using System;
using System.Collections.Generic;
using System.Text;

namespace Sentra.PTT.Utility.Models
{
    public class MessageSeenReq
    {
        public string ObjectID { get; set; }
        public int UserID { get; set; }
        public int ChannelID { get; set; }
        public int CompanyID { get; set; } = 0;
    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace Sentra.PTT.Utility.Models
{
    public class GetParticipantsByChannelIDReq
    {
        public int ChannelID { get; set; }
        public int OwnerID { get; set; }
    }
}

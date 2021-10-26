using System;
using System.Collections.Generic;
using System.Text;

namespace Sentra.PTT.Utility.Models
{
    public class ChannelPermissionReq
    {
        public List<int> LstCompanyUserID { get; set; }
        public int ChannelID { get; set; }
        public int CompanyUserID { get; set; }
        public List<int> LstChannelID { get; set; }
        public int CompanyID { get; set; }

        public ChannelPermissionReq()
        {
            LstCompanyUserID = new List<int>();
            LstChannelID = new List<int>();
        }
    }
}

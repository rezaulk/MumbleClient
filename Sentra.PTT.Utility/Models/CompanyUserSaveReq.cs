using System;
using System.Collections.Generic;
using System.Text;

namespace Sentra.PTT.Utility.Models
{
    public class CompanyUserSaveReq
    {
        public string PhoneNumber { get; set; }
        public int UserID { get; set; }
        public int CompanyID { get; set; }
        public int PickType { get; set; }
    }
}

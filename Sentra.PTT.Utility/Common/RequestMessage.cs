/*
 * Created By  	: Md. Mozaffar Rahman Sebu
 * Created Date	: Aug,2020
 * Updated By  	: Md. Mozaffar Rahman Sebu
 * Updated Date	: June,2021
 * (c) NybSys Ltd.
 */
using System;
using System.Collections.Generic;
using System.Text;

namespace Sentra.PTT.Utility.Common
{
    public class RequestMessage
    {
        // public string Token { get; set; }
        public int ID { get; set; }
        public object RequestObj { get; set; }
        public string UserID { get; set; }
        public int CompanyID { get; set; }

        //Pagination
        public int PageIndex { get; set; } = 1;
        public int PageSize { get; set; } = 20;
    }

    public class RequestMessages
    {
        // public string Token { get; set; }
        public int ID { get; set; }
     
        public string UserID { get; set; }
        public int CompanyID { get; set; }

        //Pagination
        public int PageIndex { get; set; } = 1;
        public int PageSize { get; set; } = 20;
    }
}

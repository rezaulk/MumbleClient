/*
 * Created By  	: Md. Mozaffar Rahman Sebu
 * Created Date	: Aug,2020
 * Updated By  	: Md. Mozaffar Rahman Sebu
 * Updated Date	: Aug,2020
 * (c) NybSys Ltd.
 */
using System;
using System.Collections.Generic;
using System.Text;

namespace Sentra.PTT.Utility.Common
{
    public class ResponseMessage
    {
        // Response related
        public object ResponseObj { get; set; }
        public string Message { get; set; }
        public int ResponseCode { get; set; }

        // Pagination
        public int PageIndex { get; set; } = 1;
        public int RecordCount { get; set; } = 20;

        public string ExecutionTime { get; set; }

        public PaginationModel Pagination { get; set; }
    }
}

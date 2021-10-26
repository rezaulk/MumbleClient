/*
 * Created By  	: MD. Tareq Haider
 * Created Date	: Oct,2021
 * Updated By  	: MD. Tareq Haider
 * Updated Date	: Oct,2021
 * (c) NybSys Ltd.
 */
using System;
using System.Collections.Generic;
using System.Text;

namespace Sentra.PTT.Utility.Common
{
    public class PaginationModel
    {
        const int MaxPageSize = 15;
        private int _pageSize;
        public int PageSize
        {
            get => _pageSize;
            set => _pageSize = (value > MaxPageSize) ? MaxPageSize : value;
        }

        public int CurrentPage { get; set; } = 1;
        public int ItemPerPage { get; set; } = 1;
        public int TotalItems { get; set; }
        public int TotalPages { get; set; }
        public IList<object> Items { get; set; }

        public PaginationModel()
        {
            Items = new List<object>();
        }
    }
}

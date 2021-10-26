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
    /// <summary>
    /// Represents Visitor's browser information
    /// </summary>
    public class BrowserInfo
    {
        public string DeviceName { get; set; } = string.Empty;
        public string BrowserName { get; set; } = string.Empty;
        public string OSName { get; set; } = string.Empty;
    }
}

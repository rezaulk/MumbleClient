/*
 * Created By  	: Md. Mozaffar Rahman Sebu
 * Created Date	: Aug,2020
 * Updated By  	: Md. Mozaffar Rahman Sebu
 * Updated Date	: Aug,2020
 * (c) NybSys Ltd.
 */

using Sentra.PTT.Utility.Common;
using System.Text;
using UAParser;

namespace Sentra.PTT.Utility.Common
{
    /// <summary>
    /// Represents the functionalities to find the Visitor's information
    /// </summary>
    public class ClientUtils
    {
        public static BrowserInfo GetBrowserInfo(ClientInfo clientInfo)
        {
            if (clientInfo != null)
            {
                BrowserInfo browserInfo = new BrowserInfo()
                {
                    BrowserName = GetBrowserInfo(clientInfo.UserAgent),
                    DeviceName = GetDeviceInfo(clientInfo.Device),
                    OSName = GetOperatingSystemInfo(clientInfo.OS)
                };

                return browserInfo;
            }

            return new BrowserInfo();
        }

        /// <summary>
        /// Represents the physical device info
        /// </summary>
        /// <param name="device"></param>
        /// <returns></returns>
        private static string GetDeviceInfo(Device device)
        {
            StringBuilder sb = new StringBuilder();

            if (!string.IsNullOrEmpty(device.Brand))
            {
                sb.Append(device.Brand + " ");
            }

            if (!string.IsNullOrEmpty(device.Family))
            {
                if (device.Family.EqualsWithLower("Other"))
                {
                    sb.Append("Unknown ");
                }
                else
                {
                    sb.Append(device.Family + " ");
                }
            }

            if (!string.IsNullOrEmpty(device.Model))
            {
                sb.Append(device.Model);
            }

            return sb.ToString();
        }

        /// <summary>
        /// Represents a visitor's browser info
        /// </summary>
        /// <param name="userAgent"></param>
        /// <returns></returns>
        private static string GetBrowserInfo(UserAgent userAgent)
        {
            StringBuilder sb = new StringBuilder();

            if (!string.IsNullOrEmpty(userAgent.Family))
            {
                sb.Append(userAgent.Family + " ");
            }


            if (!string.IsNullOrEmpty(userAgent.Major))
            {
                sb.Append(userAgent.Major);
            }

            return sb.ToString();
        }

        /// <summary>
        /// Represents a visitor's OS info
        /// </summary>
        /// <param name="os"></param>
        /// <returns></returns>
        private static string GetOperatingSystemInfo(OS os)
        {
            StringBuilder sb = new StringBuilder();

            if (!string.IsNullOrEmpty(os.Family))
            {
                sb.Append(os.Family + " ");
            }


            if (!string.IsNullOrEmpty(os.Major))
            {
                sb.Append(os.Major);
            }

            return sb.ToString();
        }
    }
}

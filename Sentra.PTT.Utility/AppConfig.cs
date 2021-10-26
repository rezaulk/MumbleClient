using System;
using System.Collections.Generic;
using System.Text;
/*
 * Created By  	: Md. Mozaffar Rahman Sebu
 * Created Date	: Aug,2020
 * Updated By  	: Md. Mozaffar Rahman Sebu
 * Updated Date	: Aug,2020
 * (c) NybSys Ltd.
 */

namespace Sentra.PTT.Utility
{
    /// <summary>
    /// Represents startup App configuration parameters
    /// </summary>
    public class AppConfig
    {
        /// <summary>
        /// Enable Lazy-Loading for EF Core
        /// </summary>
        public bool EnableLazyLoading { get; set; }
        /// <summary>
        /// Enable/Disable Table Name in Plural/Singular format
        /// </summary>
        public bool PluralizeTableName { get; set; }


        /// <summary>
        /// Gets or sets a value indicating whether we should use Redis server for caching (instead of default in-memory caching)
        /// </summary>
        public bool RedisCachingEnabled { get; set; }
        /// <summary>
        /// Gets or sets Redis connection string. Used when Redis caching is enabled
        /// </summary>
        public string RedisCachingConnectionString { get; set; }
        /// <summary>
        /// Gets or sets a value indicating whether the data protection system should be configured to persist keys in the Redis database
        /// </summary>
        public bool PersistDataProtectionKeysToRedis { get; set; }

        public bool UseRowNumberForPaging { get; set; }
    }
}

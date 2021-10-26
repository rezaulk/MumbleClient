/*
 * Created By  	: Md. Mozaffar Rahman Sebu
 * Created Date	: Aug,2020
 * Updated By  	: Md. Mozaffar Rahman Sebu
 * Updated Date	: Aug,2020
 * (c) NybSys Ltd.
 */
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace Sentra.PTT.Utility.Common
{
    public static class JSONConvert
    {
        /// <summary>
        /// Convert a JSON string into a custom class with included Serialize rules
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="jsonString"></param>
        /// <returns></returns>
        public static T Convert<T>(string jsonString) where T : class
        {
            var settings = new JsonSerializerSettings
            {
                NullValueHandling = NullValueHandling.Ignore,
                MissingMemberHandling = MissingMemberHandling.Ignore,
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore
            };

            return JsonConvert.DeserializeObject<T>(jsonString, settings);
        }

        /// <summary>
        /// Convert a JSON string into a custom object with included Serialize rules
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static T Convert<T>(object obj) where T : class
        {
            var settings = new JsonSerializerSettings
            {
                NullValueHandling = NullValueHandling.Ignore,
                MissingMemberHandling = MissingMemberHandling.Ignore,
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore
            };
            return JsonConvert.DeserializeObject<T>(JsonConvert.SerializeObject(obj), settings);
        }

        /// <summary>
        /// Convert a JSON string into a custom class with JsonSerializerSettings parameter
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="jsonString">JSON String</param>
        /// <param name="settings">To specify JsonSerializerSettings's property</param>
        /// <returns></returns>
        public static T Convert<T>(string jsonString, JsonSerializerSettings settings) where T : class
        {
            return JsonConvert.DeserializeObject<T>(jsonString, settings);
        }
        /// <summary>
        /// Convert a JSON string into a custom object with JsonSerializerSettings parameter
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="obj"></param>
        /// <param name="settings"></param>
        /// <returns></returns>
        public static T Convert<T>(object obj, JsonSerializerSettings settings) where T : class
        {
            return JsonConvert.DeserializeObject<T>(JsonConvert.SerializeObject(obj), settings);
        }
        /// <summary>
        /// Convert a custom .Net object to a JSON string
        /// </summary>
        /// <param name="obj">.Net object</param>
        /// <returns></returns>
        public static string ConvertString(object obj)
        {
            return JsonConvert.SerializeObject(obj);
        }

        public class IgnorePropertiesResolver : DefaultContractResolver
        {
            private readonly HashSet<string> ignoreProps;
            public IgnorePropertiesResolver(IEnumerable<string> propNamesToIgnore)
            {
                this.ignoreProps = new HashSet<string>(propNamesToIgnore);
            }

            protected override JsonProperty CreateProperty(MemberInfo member, MemberSerialization memberSerialization)
            {
                JsonProperty property = base.CreateProperty(member, memberSerialization);
                if (this.ignoreProps.Contains(property.PropertyName))
                {
                    property.ShouldSerialize = _ => false;
                }
                return property;
            }
        }
    }
}

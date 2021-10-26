/*
 * Created By  	: Md. Mozaffar Rahman Sebu
 * Created Date	: Aug,2020
 * Updated By  	: Md. Mozaffar Rahman Sebu
 * Updated Date	: Aug,2020
 * (c) NybSys Ltd.
 */
using System.ComponentModel;

namespace Sentra.PTT.Utility
{
    public class AppEnums
    {
        public enum Status
        {
            Active = 1,
            InActive = 1,
            Pending = 3
        }

        

        public enum Action
        {
            Insert = 1,
            Update,
            Delete,
            View,
            Other
        }

        public enum TokenAlgorithm
        {
            [Description("HS256")]
            HmacSha256,
            [Description("HS384")]
            HmacSha384,
            [Description("HS512")]
            HmacSha512,
            [Description("RS256")]
            RsaSha256,
            [Description("RS384")]
            RsaSha384,
            [Description("RS512")]
            RsaSha512,
            [Description("ES256")]
            EcdsaSha256,
            [Description("ES384")]
            EcdsaSha384,
            [Description("ES512")]
            EcdsaSha512,
            [Description("PS256")]
            RsaSsaPssSha256,
            [Description("PS384")]
            RsaSsaPssSha384
        }
    }
}

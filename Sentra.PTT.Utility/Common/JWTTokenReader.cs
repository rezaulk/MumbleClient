/*
 * Created By  	: Md. Mozaffar Rahman Sebu
 * Created Date	: Aug,2020
 * Updated By  	: Md. Mozaffar Rahman Sebu
 * Updated Date	: Aug,2020
 * (c) NybSys Ltd.
 */
using System.IdentityModel.Tokens.Jwt;
using System.Linq;

namespace Sentra.PTT.Utility.Common
{
    /// <summary>
    /// Represent the Read functionality of JWT Token
    /// </summary>
    public static class JWTTokenReader
    {
        /// <summary>
        /// Return the value for specific claim from the token
        /// </summary>
        /// <param name="ClaimType"></param>
        /// <param name="token"></param>
        /// <returns></returns>
        public static string GetTokenValue(string ClaimType, string token)
        {
            var handler = new JwtSecurityTokenHandler();
            var tokenClaims = handler.ReadToken(token) as JwtSecurityToken;
            return tokenClaims.Claims.First(claim => claim.Type == ClaimType).Value;
        }
    }
}

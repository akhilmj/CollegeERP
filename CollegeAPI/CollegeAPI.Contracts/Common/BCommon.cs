using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CollegeAPI.Contracts.Common
{
    public class BCommon
    {
        public BCommon()
        {

        }
        public static string GenerateJSONWebToken(string userName,string Issuer,string Key)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Key));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                issuer: Issuer,
                audience: Issuer,
                claims: null,
                expires: DateTime.Now.AddMinutes(120),
                signingCredentials: credentials);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}

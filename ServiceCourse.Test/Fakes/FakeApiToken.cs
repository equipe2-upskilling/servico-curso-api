using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Text;

namespace ServiceCourse.Test.Fakes
{
    public static class FakeApiToken
    {
        public const string Issuer = "http://api.test/";
        public const string Audience = "http://client.test/";
        public const string Secret = "07d7194f-6535-4325-bc02-6b56c4b4c6e8";

        public static string Generate()
        {
            var token = new JwtSecurityToken(
                issuer: Issuer,
                audience: Audience,
                notBefore: DateTime.UtcNow,
                signingCredentials: new SigningCredentials(
                    key: new SymmetricSecurityKey(Encoding.ASCII.GetBytes(Secret)),
                    algorithm: SecurityAlgorithms.HmacSha256
                )
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}

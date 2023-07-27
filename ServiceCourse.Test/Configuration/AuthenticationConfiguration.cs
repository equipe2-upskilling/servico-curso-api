using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using ServiceCourse.Test.Fakes;
using System.Text;

namespace ServiceCourse.Test.Configuration
{
    public static class AuthenticationConfiguration
    {
        public static void AddTestAuthentication(this IServiceCollection services)
        {
            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(options =>
            {
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidIssuer = FakeApiToken.Issuer,
                    ValidAudience = FakeApiToken.Audience,
                    IssuerSigningKey = new SymmetricSecurityKey(
                        key: Encoding.ASCII.GetBytes(FakeApiToken.Secret)
                    ),
                    RequireExpirationTime = false,
                    ClockSkew = TimeSpan.Zero
                };
            });
        }
    }
}

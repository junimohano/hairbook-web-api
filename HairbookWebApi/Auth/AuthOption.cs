using System;
using Microsoft.IdentityModel.Tokens;

namespace HairbookWebApi.Auth
{
    public class AuthOption
    {
        public const string Audience = "Hairbook";
        public const string Issuer = "HairbookWebApi";
        public static RsaSecurityKey Key { get; } = new RsaSecurityKey(RsaKeyHelper.GenerateKey());
        public static SigningCredentials SigningCredentials { get; } = new SigningCredentials(Key, SecurityAlgorithms.RsaSha256Signature);

        public static TimeSpan ExpiresSpan { get; } = TimeSpan.FromHours(5);
        public const string TokenType = "Bearer";

        public const string AuthenticationScheme = "ApplicationCookie";
    }
}

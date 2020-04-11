namespace Revendoo.Api.Auth
{
    public class AuthSettings
    {
        public string Secret { get; set; }

        public int ExpiresInHours { get; set; }
        public string Issuer { get; set; }
        public string Audience { get; set; }
    }
}

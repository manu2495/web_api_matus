namespace web_api.Security
{
    public class TokenSecurityModel
    {
        public string Token { get; set; }
        public DateTime Expiration { get; set; }
    }
}

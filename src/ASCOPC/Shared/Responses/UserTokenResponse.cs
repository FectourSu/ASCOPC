namespace ASCOPC.Shared.Responses
{
    public class UserTokenResponse
    {
        public string Token { get; set; }

        public DateTime Expiration { get; set; }
    }
}

namespace web_api.Helpers
{
    public class TokenHelper
    {
        public static string GetToken(HttpRequest request)
        {
            var headers = request.Headers;
            string token = "ND";

            if (headers.ContainsKey("Authorization"))
                token = headers["Authorization"];

            return token;
        }
    }
}

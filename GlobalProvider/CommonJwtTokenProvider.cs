using GlobalProvider.HttpClient;

namespace GlobalProvider.GlobalProvider
{
    public class CommonJwtTokenProvider : IJwtTokenProvider
    {
        public string Get()
        {
            return "token";
        }
    }
}
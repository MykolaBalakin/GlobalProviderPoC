using GlobalProvider.HttpClient;

namespace GlobalProvider.ServiceClient
{
    public class SomeHttpClient : HttpClient.HttpClient, ISomeHttpClient
    {
        public SomeHttpClient(IJwtTokenProvider jwtTokenProvider) : base(jwtTokenProvider)
        {

        }
    }
}
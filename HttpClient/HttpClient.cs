namespace GlobalProvider.HttpClient
{
    public abstract class HttpClient
    {
        protected HttpClient(IJwtTokenProvider jwtTokenProvider)
        {
        }
    }
}
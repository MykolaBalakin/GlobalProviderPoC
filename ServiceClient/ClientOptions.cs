using System;
using GlobalProvider.HttpClient;

namespace GlobalProvider.ServiceClient
{
    public class ClientOptions
    {
        public Type JwtTokenProvider { get; private set; }

        public ClientOptions()
        {
        }

        public ClientOptions UseJwtTokenProvider<TJwtTokenProvider>()
            where TJwtTokenProvider : IJwtTokenProvider
        {
            JwtTokenProvider = typeof(TJwtTokenProvider);
            return this;
        }
    }
}
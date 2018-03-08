namespace GlobalProvider.HttpClient
{
    public class FactoryBasedJwtTokenProvider : FactoryBasedProviderBase<IJwtTokenProvider>, IJwtTokenProvider
    {
        public FactoryBasedJwtTokenProvider(IProviderFactory<IJwtTokenProvider> factory) : base(factory)
        {
        }

        public string Get() => Provider.Get();
    }
}
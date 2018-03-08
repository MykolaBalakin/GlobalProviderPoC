using GlobalProvider.HttpClient;

namespace GlobalProvider.GlobalProvider
{
    public class ProviderFactory<TProvider, TImplementation> : IProviderFactory<TProvider>
        where TImplementation : TProvider
    {
        private readonly TImplementation _providerImplementation;

        public ProviderFactory(TImplementation providerImplementation)
        {
            _providerImplementation = providerImplementation;
        }

        public TProvider Create()
        {
            return _providerImplementation;
        }
    }
}
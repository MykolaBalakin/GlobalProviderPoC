using System;

namespace GlobalProvider.HttpClient
{
    public class FactoryBasedProviderBase<TProvider>
    {
        private readonly Lazy<TProvider> _provider;
        protected TProvider Provider => _provider.Value;

        public FactoryBasedProviderBase(IProviderFactory<TProvider> factory)
        {
            _provider = new Lazy<TProvider>(factory.Create);
        }
    }
}
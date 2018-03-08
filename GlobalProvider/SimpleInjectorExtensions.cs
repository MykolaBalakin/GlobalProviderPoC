using GlobalProvider.HttpClient;
using SimpleInjector;

namespace GlobalProvider.GlobalProvider
{
    public static class SimpleInjectorExtensions
    {
        public static void AddHttpClientProviders(this Container container)
        {
            container.RegisterSingleton<CommonJwtTokenProvider>();
            container.RegisterSingleton<
                IProviderFactory<IJwtTokenProvider>,
                ProviderFactory<IJwtTokenProvider, CommonJwtTokenProvider>>();
        }
    }
}
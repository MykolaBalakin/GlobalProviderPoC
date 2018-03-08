using System;
using System.Linq;
using GlobalProvider.HttpClient;
using SimpleInjector;

namespace GlobalProvider.ServiceClient
{
    public static class SimpleInjectorExtensions
    {
        private const string NotSetErrorMessage = "{0} is not set. Invoke options. Use{0} method to set I{0} implementation.";

        public static void AddClient(this Container container)
        {
            container.AddClient(c => { });
        }

        public static void AddClient(this Container container,Action<ClientOptions> configurator)
        {
            var options = new ClientOptions();
            configurator(options);

            container.RegisterSingleton(options);

            var currentRegistrations = container.GetCurrentRegistrations();
            if (currentRegistrations.Any(c => c.ServiceType == typeof(IProviderFactory<IJwtTokenProvider>)))
            {
                container.RegisterSingletonForUserManagementClient(typeof(IJwtTokenProvider), typeof(FactoryBasedJwtTokenProvider));
            }
            else
            {
                AssertProviderIsSet(options.JwtTokenProvider, nameof(options.JwtTokenProvider));
                container.RegisterSingletonForUserManagementClient(typeof(IJwtTokenProvider), options.JwtTokenProvider);
            }

            container.RegisterSingleton<ISomeHttpClient, SomeHttpClient>();
        }

        private static void RegisterSingletonForUserManagementClient(this Container container, Type service, Type implementation)
        {
            container.RegisterConditional(
                service,
                context => implementation,
                Lifestyle.Singleton,
                context => context.Consumer.ImplementationType == typeof(SomeHttpClient)
            );
        }

        private static void AssertProviderIsSet(Type providerType, string providerName)
        {
            if (providerType == null)
            {
                throw new InvalidOperationException(string.Format(NotSetErrorMessage, providerName));
            }
        }
    }
}
using System;
using GlobalProvider.GlobalProvider;
using GlobalProvider.ServiceClient;
using SimpleInjector;

namespace GlobalProvider
{
    class Program
    {
        static void Main(string[] args)
        {
            var container = new Container();
            container.AddHttpClientProviders();
            container.AddClient();
            container.Verify();
            Console.WriteLine("Ok");
        }
    }
}
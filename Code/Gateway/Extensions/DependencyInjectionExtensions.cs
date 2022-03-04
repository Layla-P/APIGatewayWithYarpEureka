using Steeltoe.Discovery;
using Yarp.ReverseProxy.Configuration;


namespace Gateway.Extensions
{
    public static class DependencyInjectionExtensions
    {
        public static IReverseProxyBuilder LoadFromMemory(this IReverseProxyBuilder builder)
        {
            var serviceProvider = builder.Services.BuildServiceProvider();
            var discoveryClient = serviceProvider.GetRequiredService<IDiscoveryClient>();

            var inMemoryConfigProvider = new InMemoryConfigProvider(discoveryClient);

            builder.Services
                .AddSingleton<IHostedService>(inMemoryConfigProvider);

            builder.Services
                .AddSingleton<IProxyConfigProvider>(inMemoryConfigProvider);

            return builder;
        }
    }
}

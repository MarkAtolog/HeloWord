using Definitions.Pages;
using Microsoft.Extensions.DependencyInjection;
using UserinterfaceTest.Steps;

namespace UserinterfaceTest.Tests
{
    public class BaseTest
    {
        private IServiceProvider serviceProvider;

        protected IServiceProvider ServiceProvider
        {
            get
            {
                if (serviceProvider == null)
                {
                    serviceProvider = BuildServices(GetServices());
                }

                return serviceProvider;
            }
        }

        private IServiceCollection GetServices()
        {
            var services = new ServiceCollection();

            services.AddSingleton<GamePage>();
            services.AddSingleton<HomePage>();
            services.AddSingleton<GamePageSteps>();
            services.AddSingleton<HomePageSteps>();

            return services;
        }

        private static IServiceProvider BuildServices(IServiceCollection services)
        {
            var options = new ServiceProviderOptions
            {
                ValidateOnBuild = true,
                ValidateScopes = true
            };
            return new DefaultServiceProviderFactory(options).CreateServiceProvider(services);
        }
    }
}

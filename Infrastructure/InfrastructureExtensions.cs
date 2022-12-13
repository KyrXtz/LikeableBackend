using SharedKernel.Interfaces;
using System.Linq;

namespace Infrastructure
{
    public static class InfrastructureExtensions
    {     
        public static IServiceCollection LoadInfrastructureServices(this IServiceCollection services)
        {
            services
                .AddFluentValidations()
                .AddApiControllers()
                .AddDbContext();

            return services;
        }
        #region internal
        private static IServiceCollection AddFluentValidations(this IServiceCollection services)
        {
            services.AddValidatorsFromAssembly(typeof(Application.ApplicationExtensions).Assembly);
            return services;
        }
        private static IServiceCollection AddDbContext(this IServiceCollection services)
        {
            var interfaceType = typeof(IAggregateRoot);

            // Get the assemblies in your application
            var assemblies = AppDomain.CurrentDomain.GetAssemblies();

            // Search the assemblies for types that implement the interface
            var implementingTypes = assemblies
            .SelectMany(a => a.GetTypes())
            .Where(t => t != interfaceType && interfaceType.IsAssignableFrom(t));

            foreach (var type in implementingTypes)
            {
                var serviceType = typeof(IAppDbContext<>).MakeGenericType(type);

                services
                    .AddTransient(serviceType, typeof(AppDbContext));
            }

            return services;
        }
        #endregion
    }
}

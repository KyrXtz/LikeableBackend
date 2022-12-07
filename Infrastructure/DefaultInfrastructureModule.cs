namespace Infrastructure
{
    public class DefaultInfrastructureModule
    {
        public static IServiceCollection Load(IServiceCollection services)
        {
            var assemblies = AppDomain.CurrentDomain.GetAssemblies();
            services.AddMediatR(assemblies);
            return services;
        }
    }
}

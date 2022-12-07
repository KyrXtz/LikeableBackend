namespace Application
{
    public class DefaultApplicationModule
    {
        public static IServiceCollection Load(IServiceCollection services)
        {
            var assemblies = AppDomain.CurrentDomain.GetAssemblies();
            services.AddMediatR(assemblies);
            return services;
        }
    }
}

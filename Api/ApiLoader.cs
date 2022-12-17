namespace Api
{
    public static class ApiLoader
    {
        public static IServiceCollection LoadApiServices(this IServiceCollection services)
        {      
            var assemblies = AppDomain.CurrentDomain.GetAssemblies();
            services.AddMediatR(assemblies);
            return services;
        }
    }
}

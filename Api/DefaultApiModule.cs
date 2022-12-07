namespace Api
{
    public static class DefaultApiModule 
    {
        public static IServiceCollection Load(IServiceCollection services)
        {
            var assemblies = AppDomain.CurrentDomain.GetAssemblies();
            services.AddMediatR(assemblies);
            return services;
        }
    }
}

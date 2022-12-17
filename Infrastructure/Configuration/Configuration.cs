namespace Infrastructure.Configuration
{
    public static class Configuration
    {
        public static IServiceCollection AddConfiguration(this IServiceCollection services, IConfiguration configuration)
        {
            services
                .ConfigureIOptions(configuration)
                .AddDbContext(configuration)
                .AddJwtAuthentication(configuration);

            return services;
        }
    }
}

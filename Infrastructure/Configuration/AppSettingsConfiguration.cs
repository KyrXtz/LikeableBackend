namespace Infrastructure.Configuration
{
    public static class AppSettingsConfiguration
    {
        public static IServiceCollection ConfigureIOptions(this IServiceCollection services, IConfiguration configuration)
        {
            services.Configure<ApplicationSettings>(configuration.GetSection(nameof(ApplicationSettings)));
            services.Configure<ValidationSettings>(configuration.GetSection(nameof(ValidationSettings)));
            return services;
        }
    }
}

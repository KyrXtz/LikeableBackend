namespace Infrastructure.Configuration
{
    public static class FluentValidationConfiguration
    {
        public static IServiceCollection AddFluentValidations(this IServiceCollection services)
        {
            services.AddValidatorsFromAssembly(typeof(ApplicationServices).Assembly);
            return services;
        }
    }
}

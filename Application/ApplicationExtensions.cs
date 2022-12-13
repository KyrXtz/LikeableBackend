namespace Application
{
    public static class ApplicationExtensions
    {
        public static IServiceCollection LoadApplicationServices(this IServiceCollection services)
        {
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));
            return services;
        }
    }
}

namespace Service
{
    public static class ServiceExtensions
    {
        public static IServiceCollection LoadServiceConfigurations(this IServiceCollection services)
        {
            return services;
        }
        public static IServiceCollection LoadServiceServices(this IServiceCollection services)
        {
            services.
                AddApplicationServices();

            return services;
        }

        #region internal
        private static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            services
                .AddTransient<IIdentityService, IdentityService>()
                .AddTransient<IProfileService, ProfileService>()
                .AddTransient<ISearchService, SearchService>()
                .AddTransient<IItemsService, ItemsService>()
                .AddScoped<ICurrentUserService, CurrentUserService>();

            return services;
        }
        #endregion
    }
}

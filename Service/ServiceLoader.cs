namespace Service
{
    public static class ServiceLoader
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

        #region privates
        private static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            services
                .AddTransient<IIdentityService, IdentityService>()
                .AddTransient<ISearchService, SearchService>()
                .AddTransient<IItemsService, ItemsService>()
                .AddTransient<ICurrentUserService, CurrentUserService>()
                .AddTransient<IUserService, UserService>();

            return services;
        }
        #endregion
    }
}

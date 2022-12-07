namespace Infrastructure.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static ApplicationSettings GetAppSettings(this IServiceCollection services, IConfiguration configuration)
        {
            var appSettingsConfig = configuration.GetSection("ApplicationSettings");
            //services.Configure<ApplicationSettings>(appSettingsConfig);
            var appSettings = appSettingsConfig.Get<ApplicationSettings>();
            return appSettings;
        }
        public static IServiceCollection AddIdentity(this IServiceCollection services)
        {
            services
            .AddIdentity<User, IdentityRole>(options =>
             {
                 options.Password.RequiredLength = 6;
                 options.Password.RequireDigit = false;
                 options.Password.RequireLowercase = false;
                 options.Password.RequireUppercase = false;
                 options.Password.RequireNonAlphanumeric = false;
             })
            .AddRoles<IdentityRole>()
            //.AddIdentityCore<IdentityUser>() //Check .AddIdentity<IdentityUser, IdentityRole>()
            .AddEntityFrameworkStores<AppDbContext>();

            return services;
        }

        public static IServiceCollection AddJwtAuthentication(this IServiceCollection services, ApplicationSettings appSettings)
        {
            var key = Encoding.ASCII.GetBytes(appSettings.Secret);
            services
                .AddAuthentication(x =>
                {
                    x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                    x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                })
                .AddJwtBearer(x =>
                {
                    x.RequireHttpsMetadata = false;
                    x.SaveToken = true;
                    x.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuerSigningKey = true,
                        IssuerSigningKey = new SymmetricSecurityKey(key),
                        ValidateIssuer = false,
                        ValidateAudience = false
                    };
                });
            return services;
        }

        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            services
                .AddTransient<IIdentityService, IdentityService>()
                .AddTransient<IProfileService, ProfileService>()
                .AddTransient<ISearchService, SearchService>()
                .AddTransient<IItemsService, ItemsService>()
                .AddScoped<ICurrentUserService, CurrentUserService>();                


            return services;
        }

        public static IServiceCollection AddApiControllers(this IServiceCollection services)
        {
            services.AddControllers(options =>
            {
                options.Filters.Add<ModelOrNotFoundActionFilter>();
            });

            return services;
        }
    }
}

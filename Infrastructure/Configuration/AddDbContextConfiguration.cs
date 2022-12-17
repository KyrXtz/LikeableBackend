namespace Infrastructure.Configuration
{
    public static class AddDbContextConfiguration
    {
        public static IServiceCollection AddDbContext(this IServiceCollection services, IConfiguration configuration)
        {
            // Add services to the container.
            var connectionString = configuration.GetConnectionString("DefaultConnection");
            services.AddDbContext<AppDbContext>(options =>
                options.UseSqlServer(connectionString))
                .AddIdentity();

            return services;
        }

        #region privates
        private static IServiceCollection AddIdentity(this IServiceCollection services)
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
        #endregion
    }
}

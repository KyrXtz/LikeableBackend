namespace Infrastructure
{
    public static class InfrastructureLoader
    {     
        public static IServiceCollection LoadInfrastructureServices(this IServiceCollection services)
        {
            services
                .AddFluentValidations()
                .AddApiControllers()
                .AddDbContext();

            return services;
        }
        public static IApplicationBuilder InitDatabase(this IApplicationBuilder app)
        {
            app.ApplyMigrations()
                .CreateRoles();

            return app;
        }
        public static IApplicationBuilder LoadSwagger(this IApplicationBuilder app)
        {

            app.UseSwagger();
            app.UseSwaggerUI(options =>
            {
                options.SwaggerEndpoint("/swagger/v1/swagger.json", "v1");
                options.RoutePrefix = string.Empty;
            });

            return app;
        }

        #region privates
        private static IServiceCollection AddFluentValidations(this IServiceCollection services)
        {
            services.AddValidatorsFromAssembly(typeof(Application.ApplicationLoader).Assembly);
            return services;
        }
        private static IServiceCollection AddDbContext(this IServiceCollection services)
        {
            var interfaceType = typeof(IAggregateRoot);

            // Get the assemblies in your application
            var assemblies = AppDomain.CurrentDomain.GetAssemblies();

            // Search the assemblies for types that implement the interface
            var implementingTypes = assemblies
            .SelectMany(a => a.GetTypes())
            .Where(t => t != interfaceType && interfaceType.IsAssignableFrom(t));

            foreach (var type in implementingTypes)
            {
                var serviceType = typeof(IAppDbContext<>).MakeGenericType(type);

                services
                    .AddTransient(serviceType, typeof(AppDbContext));
            }

            return services;
        }
        private static IServiceCollection AddApiControllers(this IServiceCollection services)
        {
            services.AddControllers(options =>
            {
                options.Filters.Add<ValidatorActionFilter>();
            });

            return services;
        }
        private static IApplicationBuilder ApplyMigrations(this IApplicationBuilder app)
        {
            using var services = app.ApplicationServices.CreateScope();

            var dbContext = services.ServiceProvider.GetService<AppDbContext>();

            dbContext.Database.Migrate();

            return app;
        }

        private static IApplicationBuilder CreateRoles(this IApplicationBuilder app)
        {
            using var services = app.ApplicationServices.CreateScope();

            var RoleManager = services.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();
            var UserManager = services.ServiceProvider.GetRequiredService<UserManager<User>>();
            var appSettings = services.ServiceProvider.GetRequiredService<IOptions<ApplicationSettings>>().Value;
            string[] roleNames = Enum.GetNames(typeof(Constants.Roles));
            IdentityResult roleResult;

            foreach (var roleName in roleNames)
            {
                var roleExist = RoleManager.RoleExistsAsync(roleName).Result;
                if (!roleExist)
                {
                    roleResult = RoleManager.CreateAsync(new IdentityRole(roleName)).Result;
                }
            }

            var user = User.Create(appSettings.AdminUsername, appSettings.AdminEmail);
            var userPWD = appSettings.AdminPassword;
            var _user = UserManager.FindByEmailAsync(appSettings.AdminEmail).Result;

            if (_user == null)
            {
                var createAdmin = UserManager.CreateAsync(user, userPWD).Result;
                if (createAdmin.Succeeded)
                {
                    //here we tie the new user to the role
                    var res = UserManager.AddToRoleAsync(user, Constants.Roles.Admin.ToString()).Result;
                }
            }

            return app;
        }
        #endregion
    }
}

namespace Infrastructure.Extensions
{
    public static class ApplicationBuilderExtensions
    {
        public static void ApplyMigrations(this IApplicationBuilder app)
        {
            using var services = app.ApplicationServices.CreateScope();

            var dbContext = services.ServiceProvider.GetService<AppDbContext>();

            dbContext.Database.Migrate();
        }

        public static async Task CreateRoles(this IApplicationBuilder app)
        {
            using var services = app.ApplicationServices.CreateScope();

            var RoleManager = services.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();
            var UserManager = services.ServiceProvider.GetRequiredService<UserManager<User>>();
            string[] roleNames = Enum.GetNames(typeof(Constants.Roles));
            IdentityResult roleResult;

            foreach (var roleName in roleNames)
            {
                var roleExist = await RoleManager.RoleExistsAsync(roleName);
                if (!roleExist)
                {
                    roleResult = await RoleManager.CreateAsync(new IdentityRole(roleName));
                }
            }

            var user = Domain.Aggregates.User.Create(null, "admin", "admin@admin");
            var userPWD = "agiosnikolaos";
            var _user = await UserManager.FindByEmailAsync("admin@admin");

            if (_user == null)
            {
                var createAdmin = await UserManager.CreateAsync(user, userPWD);
                if (createAdmin.Succeeded)
                {
                    //here we tie the new user to the role
                    await UserManager.AddToRoleAsync(user, Constants.Roles.Admin.ToString());

                }
            }
        }

    }
}

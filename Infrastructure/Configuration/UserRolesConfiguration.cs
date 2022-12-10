namespace Infrastructure.Configuration
{
    public class UserRolesConfiguration
    {
        public async Task AddUserRoles(IServiceProvider serviceProvider)
        {
            //initializing custom roles 
            var RoleManager = serviceProvider.GetRequiredService<RoleManager<IdentityRole>>();
            var UserManager = serviceProvider.GetRequiredService<UserManager<User>>();
            string[] roleNames = { "Admin", "User" };
            IdentityResult roleResult;

            foreach (var roleName in roleNames)
            {
                var roleExist = await RoleManager.RoleExistsAsync(roleName);
                if (!roleExist)
                {
                    //create the roles and seed them to the database: Question 1
                    roleResult = await RoleManager.CreateAsync(new IdentityRole(roleName));
                }
            }

            var user = Domain.Aggregates.User.Create(null, "admin", "admin@admin");
            var userPWD = "admin";
            var _user = await UserManager.FindByEmailAsync("admin@admin");

            if (_user == null)
            {
                var createAdmin = await UserManager.CreateAsync(user, userPWD);
                if (createAdmin.Succeeded)
                {
                    //here we tie the new user to the role
                    await UserManager.AddToRoleAsync(user, "Admin");

                }
            }
        }
    }
}

using Microsoft.AspNetCore.Identity;

namespace ClinicDM.Helpers
{
    public static class AdminSeeder
    {
        public static async Task CreatAdmin(WebApplication app){
             
            var scope = app.Services.CreateScope();
            var UserManager = scope.ServiceProvider.GetRequiredService<UserManager<IdentityUser>>();

            var AdminEmail = "Admin@gmail.com";
            var AdminPassword = "Admin1234";

            var admin = await UserManager.FindByEmailAsync(AdminEmail);
            if(admin == null)
            {
                admin = new IdentityUser
                {
                    UserName = AdminEmail,
                    Email = AdminEmail,
                    EmailConfirmed = true
                };
                var result = await UserManager.CreateAsync(admin, AdminPassword);
                if (result.Succeeded)
                {
                    await UserManager.AddToRoleAsync(admin, AppRoles.Admin.ToString());
                }
            }

        }

    }
}

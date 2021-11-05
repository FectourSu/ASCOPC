using ASCOPC.Infrastructure.Data.Entities;
using ASCOPC.Shared;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace ASCOPC.Infrastructure.Data
{
    public class DbInitializer
    {
        private static UserManager<User> _userManager;
        private static RoleManager<Role> _roleManager;
        private static ILogger<DbInitializer> _logger;

        private static async Task CreateRoleAsync(string roleName)
        {
            var result = await _roleManager.CreateAsync(new Role(roleName));

            if (!result.Succeeded)
                _logger.LogError($"Error: {string.Join("\n", result.Errors.Select(e => e.Description))}");

            _logger.LogInformation($"Created role: {roleName}");
        }

        private static async Task CreateAdminAsync()
        {
            var powerUser = new User(email: "admin@gmail.com", userName: "admin@gmail.com");
            string adminPassword = "1488";

            var result = await _userManager.CreateAsync(powerUser, adminPassword);

            if (!result.Succeeded)
                _logger.LogError($"Error: {string.Join("\n", result.Errors.Select(e => e.Description))}");

            await _userManager.AddToRoleAsync(powerUser, adminPassword);
            _logger.LogInformation($"Admin created: {powerUser.UserName}");
        }

        private static async Task EntityInitializeAsync(IServiceProvider serviceProvider)
        {
            _userManager = serviceProvider.GetService<UserManager<User>>();
            _roleManager = serviceProvider.GetService<RoleManager<Role>>();
            _logger = serviceProvider.GetRequiredService<ILogger<DbInitializer>>();

            string[] roleNames = { Roles.Admin, Roles.Moderator, Roles.User };
            _logger.LogInformation("Checking role registration");

            foreach (var roleName in roleNames)
            {
                var roleExist = await _roleManager.RoleExistsAsync(roleName);

                if (!roleExist)
                    await CreateRoleAsync(roleName);
            }

            var user = await _userManager.FindByEmailAsync("adming@gmail.com");
            _logger.LogInformation("Checking account registration");

            if (user == null)
                await CreateAdminAsync();
        }

        public void Initialize(ModelBuilder builder)
        { 
            if (builder == null)
                throw new ArgumentNullException(nameof(builder));

            
        }
    }
}
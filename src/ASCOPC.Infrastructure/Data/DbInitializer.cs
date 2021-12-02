using ASCOPC.Domain.Entities;
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
        
        private static async Task CreateRolesAsync(string email, string username, string password, string role)
        {
            var powerUser = new User(email: email, userName: username);
            string adminPassword = password;

            var result = await _userManager.CreateAsync(powerUser, adminPassword);

            if (!result.Succeeded)
                _logger.LogError($"Error: {string.Join("\n", result.Errors.Select(e => e.Description))}");

            await _userManager.AddToRoleAsync(powerUser, role);
            _logger.LogInformation($"Admin created: {powerUser.UserName}");
        }

        public static async Task IdentityInitializeAsync(IServiceProvider serviceProvider)
        {
            _userManager = serviceProvider.GetRequiredService<UserManager<User>>();
            _roleManager = serviceProvider.GetRequiredService<RoleManager<Role>>();
            _logger = serviceProvider.GetRequiredService<ILogger<DbInitializer>>();

            string[] roleNames = { Roles.Admin, Roles.Moderator, Roles.User };
            _logger.LogInformation("Checking role registration");

            foreach (var roleName in roleNames)
            {
                var roleExist = await _roleManager.RoleExistsAsync(roleName);

                if (!roleExist)
                    await CreateRoleAsync(roleName);
            }

            _logger.LogInformation("Checking accounts registration");

            if (await _userManager.FindByEmailAsync("admin@gmail.com") is null)
                await CreateRolesAsync("admin@gmail.com", "admin", "FectourSu1488", "Admin");

            if (await _userManager.FindByEmailAsync("editor@gmail.com") is null)
                await CreateRolesAsync("editor@gmail.com", "editor", "Moderator1488", "Moderator");

            if (await _userManager.FindByEmailAsync("user@gmail.com") is null)
                await CreateRolesAsync("user@gmail.com", "user", "User1488", "User");
        }

        public static void Initialize(ModelBuilder builder)
        {
            if (builder == null)
                throw new ArgumentNullException(nameof(builder));

            builder.Entity<Manufacturer>().HasData(
              new Manufacturer[]
              {
                    new Manufacturer
                    {
                        Id = 1,
                        CreateAt = DateTime.Now,
                        Name = "AMD"
                    },
                    new Manufacturer
                    {
                        Id = 2,
                        CreateAt= DateTime.Now,
                        Name = "Intel"
                    }
              });

           
            builder.Entity<ComponentType>().HasData(
              new ComponentType[]
              {
                    new ComponentType
                    {
                        Id = 1,
                        CreateAt = DateTime.Now,
                        Name = "Процессор"
                    }
              });

            builder.Entity<Component>().HasData(
              new Component[]
              {
                    new Component
                    {
                        Id = 1,
                        CreateAt = DateTime.Now,
                        Name = "AM4, 6 x 3600 МГц, L2 - 3 МБ, L3 - 32 МБ, 2хDDR4-3200 МГц, TDP 65 Вт",
                        UrlImage = "https://c.dns-shop.ru/thumb/st4/fit/500/500/6e55c08c071d9744dba9a9582eafd812/fc1ee4a47dc4a1740799e996bf0d478f8908764c5f55f176f6b0bc0ca5f5eef2.jpg.webp",
                        Desciption = "6-ядерный процессор AMD Ryzen 5 3600 OEM порадует" +
                        " высоким уровнем производительности подавляющее большинство пользователей. " +
                        "Устройство будет уверенно себя чувствовать в составе мощной игровой системы. " +
                        "Базовая частота процессора равна 3600 МГц. Турбочастота – 4200 МГц. " +
                        "Важной особенностью процессора является очень большой объем кэша третьего уровня: величина этого показателя равна 32 МБ. " +
                        "Объем кэша L2 – 3 МБ.",
                        InStock = true,
                        Rating = 4.5m,
                        Code = 1372637,
                        Price = 17.699m,
                        ManufacturerId = 1,
                        TypeId = 1,
                    }
              });
        }
    }
}
using ASCOPC.Infrastructure.Data;
using ASCOPC.Infrastructure.Data.Entities;
using ASCOPC.Infrastructure.Provider;
using ASCOPC.Infrastructure.Repositories;
using ASCOPC.Infrastructure.Services;
using ASOPC.Application.Interfaces.Data;
using ASOPC.Application.Interfaces.Provider;
using ASOPC.Application.Interfaces.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace ASCOPC.Infrastructure.Extensions
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection collection, IConfiguration configuration)
        {
            collection.AddScoped<IEmailService, EmailService>();
            collection.AddScoped<ICitilinkBasketService, CitilinkBasketService>();
            collection.AddScoped<IParserService, ParserService>();
            collection.AddScoped<IComponentMapService, ComponentMapService>();
            collection.AddScoped<IFillComponentProvider, FillComponentProvider>();
            collection.AddScoped(typeof(IUnitOfWork), typeof(UnitOfWork));

            collection.AddDbContext<ApplicationDbContext>(options =>
             {
                 options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"));
             });

            collection.AddIdentity<User, Role>(options =>
            {
                options.Password.RequiredLength = 8;
                options.Password.RequireNonAlphanumeric = false;
            })
                .AddEntityFrameworkStores<ApplicationDbContext>()
                .AddDefaultTokenProviders();

            return collection;
        }
    }
}

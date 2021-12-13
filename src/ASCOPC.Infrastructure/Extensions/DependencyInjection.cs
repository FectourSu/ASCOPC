using ASCOPC.Infrastructure.Data;
using ASCOPC.Infrastructure.Data.Entities;
using ASCOPC.Infrastructure.Provider;
using ASCOPC.Infrastructure.Repositories;
using ASCOPC.Infrastructure.Services;
using ASOPC.Application.Interfaces.Data;
using ASOPC.Application.Interfaces.Provider;
using ASOPC.Application.Interfaces.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using System.Reflection;
using System.Text;

namespace ASCOPC.Infrastructure.Extensions
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection collection, IConfiguration configuration)
        {
            collection.AddScoped<IFillComponentProvider, FillComponentProvider>();

            collection.AddScoped<IAuthenticationService, AuthenticationService>();
            collection.AddScoped<IEmailService, EmailService>();
            collection.AddScoped<ICitilinkBasketService, CitilinkBasketService>();
            collection.AddScoped<IParserService, ParserService>();
            collection.AddScoped<IComponentMapService, ComponentMapService>();
            collection.AddScoped<IBuildsService, BuildsService>();

            collection.AddScoped(typeof(IUnitOfWork), typeof(UnitOfWork));

            // builds map
            collection.AddAutoMapper(Assembly.GetExecutingAssembly());

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

            collection.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
                .AddJwtBearer(options => options.TokenValidationParameters = new TokenValidationParameters()
                {
                    ValidateIssuer = false,
                    ValidateAudience = false,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["Jwt:Key"])),
                    ClockSkew = TimeSpan.Zero
                });

            return collection;
        }
    }
}

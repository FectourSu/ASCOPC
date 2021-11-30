using Microsoft.Extensions.DependencyInjection;
using System.Reflection;
using MediatR;

namespace ASOPC.Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection collection)
        {
            collection.AddMediatR(Assembly.GetExecutingAssembly())
                   .AddAutoMapper(Assembly.GetExecutingAssembly());

            return collection;
        }
    }
}

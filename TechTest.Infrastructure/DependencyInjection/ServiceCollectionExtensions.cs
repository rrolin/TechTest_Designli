using TechTest.Core.Domain.Interfaces;
using TechTest.Infrastructure.Identity;
using TechTest.Infrastructure.Persistence;
using Microsoft.Extensions.DependencyInjection;

namespace TechTest.Infrastructure.DependencyInjection
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services)
        {
            services.AddSingleton<IEmployeeRepository, InMemoryEmployeeRepository>();
            services.AddSingleton<InMemoryAuthenticationService>();

            return services;
        }
    }
}
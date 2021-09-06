using Microsoft.Extensions.DependencyInjection;
using Service.Infra.Shared;
using Service.Infra.Users;

namespace Service.Infra
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfra(this IServiceCollection services)
        {
            //services.AddSingleton<RavenContext>();
            services.AddSingleton<UserContext>();

            return services;
        }
    }
}

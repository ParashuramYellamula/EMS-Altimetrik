using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using EMS.DataAccess.DataBaseModels;

namespace EMS.DataAccess
{
    public static class DependencyInjectionExtension
    {
        public static IServiceCollection RegisterRepositoryDependencies(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<EMSContext>
                (o => o.UseSqlServer(configuration["connectionStrings:EMSDBConnectionString"]));
            return services;
        }
    }
}

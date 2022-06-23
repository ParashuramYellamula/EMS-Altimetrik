using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using EMS.Business;
using EMS.Business.Contracts;
using EMS.Business.Implementations;

namespace EMS.API
{
    public static class DependencyInjectionExtension
    {
        public static IServiceCollection RegisterAPIDependencies(this IServiceCollection services, IConfiguration configuration)
        {
            services.RegisterBusinessDependencies(configuration);
            services.AddTransient<IUserBusiness, UserBusiness>();
            services.AddTransient<IVoterBusiness, VoterBusiness>();
            services.AddTransient<IPartyBusiness, PartyBusiness>();
            services.AddTransient<ISymbolBusiness, SymbolBusiness>();
            services.AddTransient<IConstituencyBusiness, ConstituencyBusiness>();
            services.AddTransient<ICandidateBusiness, CandidateBusiness>();
            services.AddTransient<IElectionBusiness, ElectionBusiness>();
            return services;
        }
    }
}

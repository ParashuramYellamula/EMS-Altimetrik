using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using EMS.Business.Contracts;
using EMS.Business.Implementations;
using EMS.DataAccess;
using EMS.DataAccess.Contracts;
using EMS.DataAccess.Implementations;

namespace EMS.Business
{
    public static class DependencyInjectionExtension
    {
        public static IServiceCollection RegisterBusinessDependencies(this IServiceCollection services, IConfiguration configuration)
        {
            services.RegisterRepositoryDependencies(configuration);
            services.AddTransient<IUserDataAccess, UserDataAccess>();
            services.AddTransient<IVoterDataAccess, VoterDataAccess>();
            services.AddTransient<IPartyDataAccess, PartyDataAccess>();
            services.AddTransient<ISymbolDataAccess, SymbolDataAccess>();
            services.AddTransient<IConstituencyDataAccess, ConstituencyDataAccess>();
            services.AddTransient<ICandidateDataAccess, CandidateDataAccess>();
            services.AddTransient<IElectionDataAccess, ElectionDataAccess>();
            services.AddTransient<ITokenBusiness, TokenBusiness>();
            return services;
        }
    }
}

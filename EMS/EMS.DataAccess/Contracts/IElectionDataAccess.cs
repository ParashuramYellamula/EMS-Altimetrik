using EMS.DataAccess.DataBaseModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EMS.DataAccess.Contracts
{
    public interface IElectionDataAccess
    {
        Task<bool> RegisterElection(Election election);
        Task<List<Election>> GetElections(string name);
        Task<List<string>> GetCurrentElections();
        Task<bool> RegisterVote(Election election);
    }
}

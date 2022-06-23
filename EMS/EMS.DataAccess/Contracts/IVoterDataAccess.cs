using EMS.DataAccess.DataBaseModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EMS.DataAccess.Contracts
{
    public interface IVoterDataAccess
    {
        Task<bool> RegisterVoter(Voter voter);
        Task<List<Voter>> GetVoters(string name);
    }
}

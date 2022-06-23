using EMS.DataAccess.DataBaseModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EMS.DataAccess.Contracts
{
    public interface ICandidateDataAccess
    {
        Task<bool> RegisterCandidate(Candidate voter);
        Task<List<Candidate>> GetCandidates(string name);
    }
}

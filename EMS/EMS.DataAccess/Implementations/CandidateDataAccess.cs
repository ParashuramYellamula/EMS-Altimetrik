using Microsoft.EntityFrameworkCore;
using EMS.DataAccess.Contracts;
using EMS.DataAccess.DataBaseModels;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EMS.DataAccess.Implementations
{
    public class CandidateDataAccess : ICandidateDataAccess
    {
        private readonly EMSContext _emsContext;
        public CandidateDataAccess(EMSContext emsContext)
        {
            _emsContext = emsContext;
        }
        public async Task<bool> RegisterCandidate(Candidate candidate)
        {
            if (!_emsContext.Candidates.Any(x => x.Name == candidate.Name))
            {
                await _emsContext.Candidates.AddAsync(candidate);
                _emsContext.SaveChanges();
                return true;
            }
            return false;
        }

        public async Task<List<Candidate>> GetCandidates(string constituency)
        {
            List<Candidate> candidate = new List<Candidate>();
            if(constituency != null)
            {
                candidate = await _emsContext.Candidates.Where(x => x.Constituency.Contains(constituency)).ToListAsync();
            }
            else
            {
                candidate = await _emsContext.Candidates.ToListAsync();
            }
            return candidate;
        }
    }
}

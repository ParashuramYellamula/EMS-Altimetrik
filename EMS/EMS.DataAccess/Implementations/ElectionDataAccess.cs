using Microsoft.EntityFrameworkCore;
using EMS.DataAccess.Contracts;
using EMS.DataAccess.DataBaseModels;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EMS.DataAccess.Implementations
{
    public class ElectionDataAccess : IElectionDataAccess
    {
        private readonly EMSContext _emsContext;
        public ElectionDataAccess(EMSContext emsContext)
        {
            _emsContext = emsContext;
        }
        public async Task<bool> RegisterElection(Election election)
        {
            if (!_emsContext.Elections.Any(x => x.Constituency == election.Constituency))
            {
                await _emsContext.Elections.AddAsync(election);
                _emsContext.SaveChanges();
                return true;
            }
            return false;
        }

        public async Task<bool> RegisterVote(Election election)
        {
            if (_emsContext.Elections.Any(x => x.Constituency == election.Constituency && x.Candidate == election.Candidate))
            {
                var ele = _emsContext.Elections.FirstOrDefault(x => x.Constituency == election.Constituency && x.Candidate == election.Candidate);
                ele.Votes = ele.Votes + 1;
                _emsContext.Elections.Update(ele);
                _emsContext.SaveChanges();
                return true;
            }
            return false;
        }

        public async Task<List<Election>> GetElections(string constituency)
        {
            List<Election> election = new List<Election>();
            if(constituency != null)
            {
                election = await _emsContext.Elections.Where(x => x.Constituency.Contains(constituency)).ToListAsync();
            }
            else
            {
                election = await _emsContext.Elections.ToListAsync();
            }
            return election;
        }
        public async Task<List<string>> GetCurrentElections()
        {
            return await  _emsContext.Elections.Select(x => x.Constituency).Distinct().ToListAsync();
        }
    }
}

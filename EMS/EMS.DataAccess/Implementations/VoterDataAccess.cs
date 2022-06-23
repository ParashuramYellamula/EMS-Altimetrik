using Microsoft.EntityFrameworkCore;
using EMS.DataAccess.Contracts;
using EMS.DataAccess.DataBaseModels;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EMS.DataAccess.Implementations
{
    public class VoterDataAccess : IVoterDataAccess
    {
        private readonly EMSContext _emsContext;
        public VoterDataAccess(EMSContext emsContext)
        {
            _emsContext = emsContext;
        }
        public async Task<bool> RegisterVoter(Voter voter)
        {
            if (!_emsContext.Voters.Any(x => x.FirstName == voter.FirstName))
            {
                await _emsContext.Voters.AddAsync(voter);
                _emsContext.SaveChanges();
                return true;
            }
            return false;
        }

        public async Task<List<Voter>> GetVoters(string name)
        {
            List<Voter> voters = new List<Voter>();
            if(name != null)
            {
                voters = await _emsContext.Voters.Where(x => x.FirstName.Contains(name)).ToListAsync();
            }
            else
            {
                voters = await _emsContext.Voters.ToListAsync();
            }
            return voters;
        }
    }
}

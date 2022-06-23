using Microsoft.EntityFrameworkCore;
using EMS.DataAccess.Contracts;
using EMS.DataAccess.DataBaseModels;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EMS.DataAccess.Implementations
{
    public class PartyDataAccess : IPartyDataAccess
    {
        private readonly EMSContext _emsContext;
        public PartyDataAccess(EMSContext emsContext)
        {
            _emsContext = emsContext;
        }
        public async Task<bool> RegisterParty(Party party)
        {
            if (!_emsContext.Party.Any(x => x.Name == party.Name))
            {
                await _emsContext.Party.AddAsync(party);
                _emsContext.SaveChanges();
                return true;
            }
            return false;
        }

        public async Task<List<Party>> GetPartys(string name)
        {
            List<Party> voters = new List<Party>();
            if(name != null)
            {
                voters = await _emsContext.Party.Where(x => x.Name.Contains(name)).ToListAsync();
            }
            else
            {
                voters = await _emsContext.Party.ToListAsync();
            }
            return voters;
        }
    }
}

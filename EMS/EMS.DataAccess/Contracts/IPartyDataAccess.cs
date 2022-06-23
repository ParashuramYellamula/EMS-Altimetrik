using EMS.DataAccess.DataBaseModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EMS.DataAccess.Contracts
{
    public interface IPartyDataAccess
    {
        Task<bool> RegisterParty(Party voter);
        Task<List<Party>> GetPartys(string name);
    }
}

using EMS.DataAccess.DataBaseModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EMS.DataAccess.Contracts
{
    public interface IConstituencyDataAccess
    {
        Task<bool> AddConstituency(Constituency constituency);
        Task<bool> RemoveConstituency(Constituency constituency);
        Task<List<Constituency>> GetConstituencys();
    }
}

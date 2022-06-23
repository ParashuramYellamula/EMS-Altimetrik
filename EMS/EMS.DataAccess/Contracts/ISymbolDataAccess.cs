using EMS.DataAccess.DataBaseModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EMS.DataAccess.Contracts
{
    public interface ISymbolDataAccess
    {
        Task<List<ElectionSymbol>> GetSymbols();
    }
}

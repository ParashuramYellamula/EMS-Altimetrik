using Microsoft.EntityFrameworkCore;
using EMS.DataAccess.Contracts;
using EMS.DataAccess.DataBaseModels;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EMS.DataAccess.Implementations
{
	public class SymbolDataAccess : ISymbolDataAccess
	{
		private readonly EMSContext _emsContext;
		public SymbolDataAccess(EMSContext emsContext)
		{
			_emsContext = emsContext;
		}
		public async Task<List<ElectionSymbol>> GetSymbols()
		{
			List<ElectionSymbol> symbols = new List<ElectionSymbol>();
			symbols = await _emsContext.Symbols.ToListAsync();

			return symbols;
		}
	}
}

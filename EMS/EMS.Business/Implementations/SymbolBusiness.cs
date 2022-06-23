using EMS.Business.Contracts;
using EMS.DataAccess.Contracts;
using EMS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EMS.Business.Implementations
{
	public class SymbolBusiness:ISymbolBusiness
	{
        private readonly ISymbolDataAccess _symbolDataAccess;
        public SymbolBusiness(ISymbolDataAccess symbolDataAccess)
        {
            _symbolDataAccess = symbolDataAccess;
        }
        
        public async Task<List<ElectionSymbol>> GetSymbols()
        {
            List<ElectionSymbol> symbols = new List<ElectionSymbol>();
            var symbolsDetails = (await _symbolDataAccess.GetSymbols());
            if (symbolsDetails != null)
            {
                foreach (var symbol in symbolsDetails)
                {
                    var businessMappedVoter = AutoMappingProfiler.ConvertDataAccessSymbolToBusinessSymbol(symbol);
                    symbols.Add(businessMappedVoter);
                }
            }
            return symbols;
        }
    }
}

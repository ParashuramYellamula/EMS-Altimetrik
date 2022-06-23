using EMS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EMS.Business.Contracts
{
	public interface ISymbolBusiness
	{
		Task<List<ElectionSymbol>> GetSymbols();
	}
}

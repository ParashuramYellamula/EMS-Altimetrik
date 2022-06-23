using EMS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EMS.Business.Contracts
{
	public interface IPartyBusiness
	{
		Task<bool> RegisterParty(Party voter);
		Task<List<Party>> GetPartys(string name);
	}
}

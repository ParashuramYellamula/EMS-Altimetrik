using EMS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EMS.Business.Contracts
{
	public interface IConstituencyBusiness
	{
		Task<bool> AddConstituency(Constituency constituency);
		Task<bool> RemoveConstituency(Constituency constituency);
		Task<List<Constituency>> GetConstituencys();
	}
}

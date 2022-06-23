using Microsoft.EntityFrameworkCore;
using EMS.DataAccess.Contracts;
using EMS.DataAccess.DataBaseModels;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EMS.DataAccess.Implementations
{
	public class ConstituencyDataAccess : IConstituencyDataAccess
	{
		private readonly EMSContext _emsContext;
		public ConstituencyDataAccess(EMSContext emsContext)
		{
			_emsContext = emsContext;
		}
		public async Task<bool> AddConstituency(Constituency constituency)
		{
			if (!_emsContext.Party.Any(x => x.Name == constituency.ConstituencyName))
			{
				await _emsContext.Constituency.AddAsync(constituency);
				_emsContext.SaveChanges();
				return true;
			}
			return false;
		}
		public async Task<bool> RemoveConstituency(Constituency constituency)
		{
			if (_emsContext.Constituency.Any(x => x.ConstituencyName == constituency.ConstituencyName))
			{
				constituency = _emsContext.Constituency.FirstOrDefault(x => x.ConstituencyName == constituency.ConstituencyName);
				_emsContext.Constituency.Remove(constituency);
				_emsContext.SaveChanges();
				return true;
			}
			return false;
		}

		public async Task<List<Constituency>> GetConstituencys()
		{
			List<Constituency> constituencys = new List<Constituency>();
			constituencys = await _emsContext.Constituency.ToListAsync();
			return constituencys;
		}
	}
}

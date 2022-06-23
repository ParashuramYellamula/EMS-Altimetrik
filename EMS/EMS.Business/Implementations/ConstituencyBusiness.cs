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
	public class ConstituencyBusiness : IConstituencyBusiness
    {
        private readonly IConstituencyDataAccess _constituencyDataAccess;
        public ConstituencyBusiness(IConstituencyDataAccess constituencyDataAccess)
        {
            _constituencyDataAccess = constituencyDataAccess;
        }
        public async Task<bool> AddConstituency(Constituency constituency)
        {
            DataAccess.DataBaseModels.Constituency dataAccessVoters = AutoMappingProfiler.ConvertBusinessConstituencyToDataAccessConstituency(constituency);
            return await _constituencyDataAccess.AddConstituency(dataAccessVoters);
        }

        public async Task<bool> RemoveConstituency(Constituency constituency)
        {
            DataAccess.DataBaseModels.Constituency dataAccessVoters = AutoMappingProfiler.ConvertBusinessConstituencyToDataAccessConstituency(constituency);
            return await _constituencyDataAccess.RemoveConstituency(dataAccessVoters);
        }

        public async Task<List<Constituency>> GetConstituencys()
        {
            List<Constituency> constituencys = new List<Constituency>();
            var ConstituencyDetailsc = (await _constituencyDataAccess.GetConstituencys());
            if (ConstituencyDetailsc != null)
            {
                foreach (var constituency in ConstituencyDetailsc)
                {
                    var businessMappedVoter = AutoMappingProfiler.ConvertDataAccessConstituencyToBusinessConstituency(constituency);
                    constituencys.Add(businessMappedVoter);
                }
            }
            return constituencys;
        }
    }
}

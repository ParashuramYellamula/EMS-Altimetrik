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
	public class ElectionBusiness : IElectionBusiness
    {
        private readonly IElectionDataAccess _electionDataAccess;
        public ElectionBusiness(IElectionDataAccess electionDataAccess)
        {
            _electionDataAccess = electionDataAccess;
        }
        public async Task<bool> RegisterElection(Election election)
        {
            DataAccess.DataBaseModels.Election dataAccessVoters = AutoMappingProfiler.ConvertBusinessElectionToDataAccessElection(election);
            return await _electionDataAccess.RegisterElection(dataAccessVoters);
        }

        public async Task<List<Election>> GetElections(string partySearch)
        {
            List<Election> elections = new List<Election>();
            var electionDetails = (await _electionDataAccess.GetElections(partySearch));
            if (electionDetails != null)
            {
                foreach (var election in electionDetails)
                {
                    var businessMappedVoter = AutoMappingProfiler.ConvertDataAccessElectionToBusinessElection(election);
                    elections.Add(businessMappedVoter);
                }
            }
            return elections;
        }
        public async Task<List<string>> GetCurrentElections()
		{
            return await _electionDataAccess.GetCurrentElections();
        }

        public async Task<bool> RegisterVote(Election election)
        {
            DataAccess.DataBaseModels.Election dataAccessVoters = AutoMappingProfiler.ConvertBusinessElectionToDataAccessElection(election);
            return await _electionDataAccess.RegisterVote(dataAccessVoters);
        }
    }
}

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
	public class CandidateBusiness : ICandidateBusiness
    {
        private readonly ICandidateDataAccess _candidateDataAccess;
        public CandidateBusiness(ICandidateDataAccess candidateDataAccess)
        {
            _candidateDataAccess = candidateDataAccess;
        }
        public async Task<bool> RegisterCandidate(Candidate candidate)
        {
            DataAccess.DataBaseModels.Candidate dataAccessVoters = AutoMappingProfiler.ConvertBusinessCandidateToDataAccessCandidate(candidate);
            return await _candidateDataAccess.RegisterCandidate(dataAccessVoters);
        }

        public async Task<List<Candidate>> GetCandidates(string partySearch)
        {
            List<Candidate> candidates = new List<Candidate>();
            var candidateDetails = (await _candidateDataAccess.GetCandidates(partySearch));
            if (candidateDetails != null)
            {
                foreach (var candidate in candidateDetails)
                {
                    var businessMappedVoter = AutoMappingProfiler.ConvertDataAccessCandidateToBusinessCandidate(candidate);
                    candidates.Add(businessMappedVoter);
                }
            }
            return candidates;
        }
    }
}

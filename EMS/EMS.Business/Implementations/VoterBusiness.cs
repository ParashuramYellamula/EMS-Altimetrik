using EMS.Business.Contracts;
using EMS.DataAccess.Contracts;
using EMS.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EMS.Business.Implementations
{
    public class VoterBusiness : IVoterBusiness
    {
        private readonly IVoterDataAccess _voterDataAccess;
        public VoterBusiness(IVoterDataAccess voterDataAccess)
        {
            _voterDataAccess = voterDataAccess;
        }
        public async Task<bool> RegisterVoter(Voter voter)
        {
            DataAccess.DataBaseModels.Voter dataAccessVoters = AutoMappingProfiler.ConvertBusinessVoterToDataAccessVoter(voter);
            return await _voterDataAccess.RegisterVoter(dataAccessVoters);
        }

        public async Task<List<Voter>> GetVoters(string voterSearch)
        {
            List<Voter> voters = new List<Voter>();
            var voterDetails = (await _voterDataAccess.GetVoters(voterSearch));
            if(voterDetails != null)
            {
                foreach (var voter in voterDetails)
                {
                    var businessMappedVoter = AutoMappingProfiler.ConvertDataAccessVoterToBusinessVoter(voter);
                    voters.Add(businessMappedVoter);
                }
            }          
            return voters;
        }
    }
}

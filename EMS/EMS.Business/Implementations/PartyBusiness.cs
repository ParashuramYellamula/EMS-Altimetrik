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
	public class PartyBusiness:IPartyBusiness
	{
        private readonly IPartyDataAccess _partyDataAccess;
        public PartyBusiness(IPartyDataAccess partyDataAccess)
        {
            _partyDataAccess = partyDataAccess;
        }
        public async Task<bool> RegisterParty(Party party)
        {
            DataAccess.DataBaseModels.Party dataAccessVoters = AutoMappingProfiler.ConvertBusinessPartyToDataAccessParty(party);
            return await _partyDataAccess.RegisterParty(dataAccessVoters);
        }

        public async Task<List<Party>> GetPartys(string partySearch)
        {
            List<Party> voters = new List<Party>();
            var voterDetails = (await _partyDataAccess.GetPartys(partySearch));
            if (voterDetails != null)
            {
                foreach (var voter in voterDetails)
                {
                    var businessMappedVoter = AutoMappingProfiler.ConvertDataAccessPartyToBusinessParty(voter);
                    voters.Add(businessMappedVoter);
                }
            }
            return voters;
        }
    }
}

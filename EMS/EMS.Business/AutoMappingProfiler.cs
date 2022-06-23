
namespace EMS.Business
{
    public static class AutoMappingProfiler
    {
        public static DataAccess.DataBaseModels.User ConvertBusinessUserToDataAccessUser(Models.User businessUser)
        {
            DataAccess.DataBaseModels.User dataAccessUser = new DataAccess.DataBaseModels.User()
            {
                Id = businessUser.UserId,
                Name = businessUser.Name,
                Password = businessUser.Password               
            };

            return dataAccessUser;
        }
        public static DataAccess.DataBaseModels.Voter ConvertBusinessVoterToDataAccessVoter(Models.Voter businessVoter)
        {
            DataAccess.DataBaseModels.Voter dataAccessVoter = new DataAccess.DataBaseModels.Voter()
            {
                FirstName = businessVoter.FirstName,
                LastName = businessVoter.LastName,
                Aadhar = businessVoter.Aadhar,
                Mobile = businessVoter.Mobile,
                Email = businessVoter.Email,
                Address = businessVoter.Address,
                DateOfBirth = businessVoter.DateOfBirth
            };
            return dataAccessVoter;
        }
        public static Models.Voter ConvertDataAccessVoterToBusinessVoter(DataAccess.DataBaseModels.Voter dataAccessVoter)
        {
            Models.Voter businessVoter = new Models.Voter()
            {
                FirstName = dataAccessVoter.FirstName,
                LastName = dataAccessVoter.LastName,
                Aadhar = dataAccessVoter.Aadhar,
                Mobile = dataAccessVoter.Mobile,
                Email = dataAccessVoter.Email,
                Address = dataAccessVoter.Address,
                DateOfBirth = dataAccessVoter.DateOfBirth
            };
            return businessVoter;
        }
        public static DataAccess.DataBaseModels.Party ConvertBusinessPartyToDataAccessParty(Models.Party businessVoter)
        {
            DataAccess.DataBaseModels.Party dataAccessVoter = new DataAccess.DataBaseModels.Party()
            {
                Name = businessVoter.Name,
                Description = businessVoter.Description,
                Address = businessVoter.Address,
                Symbol = businessVoter.Symbol
            };
            return dataAccessVoter;
        }
        public static Models.Party ConvertDataAccessPartyToBusinessParty(DataAccess.DataBaseModels.Party dataAccessVoter)
        {
            Models.Party businessVoter = new Models.Party()
            {
                Name = dataAccessVoter.Name,
                Description = dataAccessVoter.Description,
                Address = dataAccessVoter.Address,
                Symbol = dataAccessVoter.Symbol
            };
            return businessVoter;
        }

        public static DataAccess.DataBaseModels.Candidate ConvertBusinessCandidateToDataAccessCandidate(Models.Candidate businessVoter)
        {
            DataAccess.DataBaseModels.Candidate dataAccessCandidate = new DataAccess.DataBaseModels.Candidate()
            {
                Name = businessVoter.Name,
                Party = businessVoter.Party,
                Constituency = businessVoter.Constituency,
                Address = businessVoter.Address
            };
            return dataAccessCandidate;
        }
        public static Models.Candidate ConvertDataAccessCandidateToBusinessCandidate(DataAccess.DataBaseModels.Candidate dataAccessVoter)
        {
            Models.Candidate businessCandidate = new Models.Candidate()
            {
                Name = dataAccessVoter.Name,
                Party = dataAccessVoter.Party,
                Address = dataAccessVoter.Address,
                Constituency = dataAccessVoter.Constituency
            };
            return businessCandidate;
        }

        public static DataAccess.DataBaseModels.Election ConvertBusinessElectionToDataAccessElection(Models.Election businessVoter)
        {
            DataAccess.DataBaseModels.Election dataAccessElection = new DataAccess.DataBaseModels.Election()
            {
                Candidate = businessVoter.Candidate,
                Party = businessVoter.Party,
                Constituency = businessVoter.Constituency,
                Symbol = businessVoter.Symbol,
                Votes = businessVoter.Votes
            };
            return dataAccessElection;
        }
        public static Models.Election ConvertDataAccessElectionToBusinessElection(DataAccess.DataBaseModels.Election dataAccessVoter)
        {
            Models.Election businessElection = new Models.Election()
            {
                Candidate = dataAccessVoter.Candidate,
                Party = dataAccessVoter.Party,
                Constituency = dataAccessVoter.Constituency,
                Symbol = dataAccessVoter.Symbol,
                Votes = dataAccessVoter.Votes
            };
            return businessElection;
        }

        public static Models.ElectionSymbol ConvertDataAccessSymbolToBusinessSymbol(DataAccess.DataBaseModels.ElectionSymbol dataAccessSymbol)
        {
            Models.ElectionSymbol businessSymbol = new Models.ElectionSymbol()
            {
                Name = dataAccessSymbol.Name,
                Symbol = dataAccessSymbol.Symbol
            };
            return businessSymbol;
        }

        public static DataAccess.DataBaseModels.Constituency ConvertBusinessConstituencyToDataAccessConstituency(Models.Constituency businessVoter)
        {
            DataAccess.DataBaseModels.Constituency dataAccessConstituency = new DataAccess.DataBaseModels.Constituency()
            {
                ConstituencyName = businessVoter.ConstituencyName,
                State = businessVoter.State,
                CurrentMember = businessVoter.CurrentMember,
            };
            return dataAccessConstituency;
        }
        public static Models.Constituency ConvertDataAccessConstituencyToBusinessConstituency(DataAccess.DataBaseModels.Constituency dataAccessVoter)
        {
            Models.Constituency businessConstituency = new Models.Constituency()
            {
                ConstituencyName = dataAccessVoter.ConstituencyName,
                State = dataAccessVoter.State,
                CurrentMember = dataAccessVoter.CurrentMember
            };
            return businessConstituency;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EMS.Models.Constants
{
    public class RoutingConstants
    {
        //UserController Routing Constants
        public const string SignUp = "SignUp";
        public const string SignIn = "SignIn";

        //VoterController Routing Constants
        public const string RegisterVoter = "RegisterVoter"; 
        public const string GetVoters = "GetVoters";

        //PartyController Routing Constants
        public const string RegisterParty = "RegisterParty";
        public const string GetPartys = "GetPartys";

        //SymbolController Routing Constants
        public const string GetSymbols = "GetSymbols";

        //ConstituencyController Routing Constants
        public const string AddConstituency = "AddConstituency";
        public const string RemoveConstituency = "RemoveConstituency";
        public const string GetConstituencys = "GetConstituencys";

        //CandidateController Routing Constants
        public const string RegisterCandidate = "RegisterCandidate";
        public const string GetCandidates = "GetCandidates";

        //ElectionController Routing Constants
        public const string RegisterElection = "RegisterElection";
        public const string GetElections = "GetElections";
        public const string GetCurrentElections = "GetCurrentElections";
        public const string RegisterVote = "RegisterVote";
    }
}

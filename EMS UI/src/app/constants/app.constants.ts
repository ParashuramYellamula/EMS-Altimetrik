let baseUrl;
if(window.location.origin == "http://localhost:4200")
    baseUrl = 'http://localhost:63469';
export class Apis {
    
    static readonly devUrl = baseUrl;
    
    // login apis
    static readonly signin = '/api/User/SignIn';
    static readonly signup = '/api/User/SignUp';

    // voter apis
    static readonly getVoters = '/api/Voter/GetVoters';
    static readonly registerVoter = '/api/Voter/RegisterVoter';
 
    // party apis
    static readonly getPartys = '/api/Party/GetPartys';
    static readonly registerParty = '/api/Party/RegisterParty';
  
    // symbol apis
    static readonly getSymbols = '/api/Symbol/getSymbols';
    
    // Constituency apis
    static readonly addConstituency = '/api/Constituency/AddConstituency';
    static readonly removeConstituency = '/api/Constituency/RemoveConstituency';
    static readonly getConstituencys = '/api/Constituency/GetConstituencys';

    // Candidate apis
    static readonly registerCandidate = '/api/Candidate/RegisterCandidate';
    static readonly getCandidates = '/api/Candidate/GetCandidates';

    // Election apis
    static readonly registerElection = '/api/Election/RegisterElection';
    static readonly getElections = '/api/Election/GetElections';
    static readonly getCurrentElections = '/api/Election/GetCurrentElections';
    static readonly registerVote = '/api/Election/RegisterVote';
}
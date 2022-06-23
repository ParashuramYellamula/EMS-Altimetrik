using EMS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EMS.Business.Contracts
{
	public interface IElectionBusiness
	{
		Task<bool> RegisterElection(Election election);
		Task<List<Election>> GetElections(string name);
		Task<List<string>> GetCurrentElections();
		Task<bool> RegisterVote(Election election);
	}
}

using EMS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EMS.Business.Contracts
{
	public interface ICandidateBusiness
	{
		Task<bool> RegisterCandidate(Candidate voter);
		Task<List<Candidate>> GetCandidates(string name);
	}
}

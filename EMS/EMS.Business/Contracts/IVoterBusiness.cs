using EMS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EMS.Business.Contracts
{
    public interface IVoterBusiness
    {
        Task<bool> RegisterVoter(Voter voter);
        Task<List<Voter>> GetVoters(string name);
    }
}

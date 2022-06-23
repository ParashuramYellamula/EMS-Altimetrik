using EMS.Business.Contracts;
using EMS.Models;
using EMS.Models.Constants;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace EMS.API.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class CandidateController : ControllerBase
	{
		private readonly ICandidateBusiness _candidateBusiness;
		public CandidateController(ICandidateBusiness partyBusiness)
		{
			_candidateBusiness = partyBusiness;
		}

        [Route(RoutingConstants.RegisterCandidate)]
        [HttpPost]
        public async Task<IActionResult> RegisterCandidate(Candidate candidate)
        {
            try
            {
                bool isPartyAdded = await _candidateBusiness.RegisterCandidate(candidate);
                if (isPartyAdded)
                {
                    return Ok();
                }
                else
                {
                    return BadRequest();
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex);
            }
        }

        [Route(RoutingConstants.GetCandidates)]
        [HttpGet]
        public async Task<IActionResult> GetCandidates(string name)
        {
            try
            {
                List<Candidate> partyDetails = await _candidateBusiness.GetCandidates(name);
                if (partyDetails.Count != 0)
                {
                    return Ok(partyDetails);
                }
                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex);
            }
        }
    }
}

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
	public class ElectionController : ControllerBase
	{
		private readonly IElectionBusiness _electionBusiness;
		public ElectionController(IElectionBusiness partyBusiness)
		{
			_electionBusiness = partyBusiness;
		}

        [Route(RoutingConstants.RegisterElection)]
        [HttpPost]
        public async Task<IActionResult> RegisterElection(Election election)
        {
            try
            {
                bool isPartyAdded = await _electionBusiness.RegisterElection(election);
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

        [Route(RoutingConstants.RegisterVote)]
        [HttpPost]
        public async Task<IActionResult> RegisterVote(Election election)
        {
            try
            {
                bool isVoteCasted = await _electionBusiness.RegisterVote(election);
                if (isVoteCasted)
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
        [Route(RoutingConstants.GetElections)]
        [HttpGet]
        public async Task<IActionResult> GetElections(string name)
        {
            try
            {
                List<Election> partyDetails = await _electionBusiness.GetElections(name);
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

        [Route(RoutingConstants.GetCurrentElections)]
        [HttpGet]
        public async Task<IActionResult> GetCurrentElections()
        {
            try
            {
                List<string> electionDetails = await _electionBusiness.GetCurrentElections();
                if (electionDetails.Count != 0)
                {
                    return Ok(electionDetails);
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

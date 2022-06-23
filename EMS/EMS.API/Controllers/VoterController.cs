using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using EMS.Business.Contracts;
using EMS.Models;
using EMS.Models.Constants;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EMS.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class VoterController : ControllerBase
    {
        private readonly IVoterBusiness _voterBusiness;
        public VoterController(IVoterBusiness voterBusiness)
        {
            _voterBusiness = voterBusiness;
        }

        [Route(RoutingConstants.RegisterVoter)]
        [HttpPost]
        public async Task<IActionResult> RegisterVoter(Voter voter)
        {
            try
            {
                bool isVoterAdded = await _voterBusiness.RegisterVoter(voter);
                if (isVoterAdded)
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

        [Route(RoutingConstants.GetVoters)]
        [HttpGet]
        public async Task<IActionResult> GetVoters(string name)
        {
            try
            {
                List<Voter> votersDetails = await _voterBusiness.GetVoters(name);
                if (votersDetails.Count != 0)
                {
                    return Ok(votersDetails);
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

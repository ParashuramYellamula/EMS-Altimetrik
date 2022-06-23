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
	public class PartyController : ControllerBase
	{
		private readonly IPartyBusiness _partyBusiness;
		public PartyController(IPartyBusiness partyBusiness)
		{
			_partyBusiness = partyBusiness;
		}

        [Route(RoutingConstants.RegisterParty)]
        [HttpPost]
        public async Task<IActionResult> RegisterParty(Party party)
        {
            try
            {
                bool isPartyAdded = await _partyBusiness.RegisterParty(party);
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

        [Route(RoutingConstants.GetPartys)]
        [HttpGet]
        public async Task<IActionResult> GetPartys(string name)
        {
            try
            {
                List<Party> partyDetails = await _partyBusiness.GetPartys(name);
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

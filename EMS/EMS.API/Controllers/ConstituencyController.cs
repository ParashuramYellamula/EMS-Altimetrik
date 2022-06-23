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
	public class ConstituencyController : ControllerBase
	{
		private readonly IConstituencyBusiness _constituencyBusiness;
		public ConstituencyController(IConstituencyBusiness constituencyBusiness)
		{
			_constituencyBusiness = constituencyBusiness;
		}

        [Route(RoutingConstants.AddConstituency)]
        [HttpPost]
        public async Task<IActionResult> AddConstituency(Constituency constituency)
        {
            try
            {
                bool isPartyAdded = await _constituencyBusiness.AddConstituency(constituency);
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

        [Route(RoutingConstants.RemoveConstituency)]
        [HttpPost]
        public async Task<IActionResult> RemoveConstituency(Constituency constituency)
        {
            try
            {
                bool isPartyDeleted = await _constituencyBusiness.RemoveConstituency(constituency);
                if (isPartyDeleted)
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

        [Route(RoutingConstants.GetConstituencys)]
        [HttpGet]
        public async Task<IActionResult> GetConstituencys()
        {
            try
            {
                List<Constituency> partyDetails = await _constituencyBusiness.GetConstituencys();
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

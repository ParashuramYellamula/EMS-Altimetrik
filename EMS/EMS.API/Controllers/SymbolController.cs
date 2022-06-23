using EMS.Business.Contracts;
using EMS.Models;
using EMS.Models.Constants;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EMS.API.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class SymbolController : ControllerBase
	{
        private readonly ISymbolBusiness _symbolBusiness;
        public SymbolController(ISymbolBusiness symbolBusiness)
        {
            _symbolBusiness = symbolBusiness;
        }

        [Route(RoutingConstants.GetSymbols)]
        [HttpGet]
        public async Task<IActionResult> GetSymbols(string name)
        {
            try
            {
                List<ElectionSymbol> partyDetails = await _symbolBusiness.GetSymbols();
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

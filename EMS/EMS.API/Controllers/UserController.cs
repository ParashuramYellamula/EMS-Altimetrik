using Microsoft.AspNetCore.Mvc;
using EMS.Business.Contracts;
using EMS.Models;
using EMS.Models.Constants;
using System;
using System.Threading.Tasks;

namespace EMS.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserBusiness _userBusiness;
        public UserController(IUserBusiness userBusiness)
        {
            _userBusiness = userBusiness;
        }

        [Route(RoutingConstants.SignUp)]
        [HttpPost]
        public async Task<IActionResult> UserSignUp(User user)
        {
            try
            {
                bool isUserAdded = await _userBusiness.AddUser(user);

                if (isUserAdded)
                {
                    return Ok();
                }
                return BadRequest();
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex);
            }
        }

        [Route(RoutingConstants.SignIn)]
        [HttpPost]
        public async Task<IActionResult> ValidateLogin(User user)
        {
            try
            {
                var token = await _userBusiness.ValidateUser(user);

                if (token != null)
                {
                    return Ok(token);
                }
                else
                {
                    return Unauthorized();
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex);
            }
        }
    }
}

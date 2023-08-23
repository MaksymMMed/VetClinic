using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using VetClinic.BLL.DTO.Request;
using VetClinic.BLL.DTO.Response;
using VetClinic.BLL.Services.Interfaces;
using VetClinic.DAL.Exeptions;

namespace VetClinic.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerIdentityController:ControllerBase
    {
        private readonly ICustomerService Service;

        public CustomerIdentityController(ICustomerService _Service)
        {
            Service = _Service;
        }

        [HttpPost("SignIn")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<JwtResponse>> SignInAsync([FromBody] SignInRequest request)
        {
            try
            {
                var response = await Service.SingIn(request);
                return Ok(response);
            }
            catch (NotFoundException e)
            {
                return NotFound(new { e.Message });
            }
            /*
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { e.Message });
            }*/
        }

        [HttpPost("SignUp")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<string>> SignUpAsync([FromBody] SignUpRequest request)
        {
            try
            {
                var response = await Service.SingUp(request);
                return Ok(response);
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { e.Message });
            }
        }

    }
}

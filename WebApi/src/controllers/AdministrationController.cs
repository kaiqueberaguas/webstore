using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebApi.src.Sercutity;

namespace WebApi.Src.Controllers
{


    [Route("api/v1/[Controller]")]
    [Consumes("application/json")]
    [Produces("application/json")]
    // [Authorize("Bearer")]
    //[Authorize(Roles = "ADMIN")]
    [ApiController]
    public class AdministrationController : ControllerBase
    {
        private readonly IAdmintrationService _admintrationService;

        public AdministrationController(IAdmintrationService admintrationService)
        {
            _admintrationService = admintrationService;
        }

        [HttpPost("role")]
        public async Task<IActionResult> CreateRole([FromQuery] string role)
        {
            await _admintrationService.CreateRole(role);
            return Ok();
        }

        [HttpDelete("role/{role}")]
        public async Task<IActionResult> UpdateRole([FromRoute] string role)
        {
            await _admintrationService.DeleteRole(role);
            return Ok();
        }

        [HttpPut("route")]
        public async Task<IActionResult> UpdatePermission([FromBody] UserAcess userAcess)
        {
            await _admintrationService.UpdatePermission(userAcess);
            return Ok();
        }
    }
}
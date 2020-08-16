using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using webApi.src.Sercutity;
using webApi.src.Sercutity.AuthorizationModels;

namespace WebApi.src.controllers
{

    [Route("api/[Controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {

        private readonly RegisterUserManager _registerUserManager;

        public AuthController(RegisterUserManager registerUserManager)
        {
            _registerUserManager = registerUserManager;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegisterUser register)
        {
            var result = await _registerUserManager.Register(register);
            if(!result.Succeeded) return BadRequest(result.Errors);
            return CreatedAtAction(nameof(Login),null);
        }        

        [HttpPost("login")]
        public async Task<ActionResult<Token>> Login(
            [FromBody] AccessCredentials login,
            [FromServices] AccessManager accessManager)
        {
            if (accessManager.ValidateCredentials(login))
            {
                return accessManager.GenerateToken(login);
            }
            else
            {
                return BadRequest("Erro ao fazer login");
            }
        }
    }
}
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using WebApi.src.models.authorizationModels;

namespace WebApi.src.controllers
{
    
    [Route("api/[Controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {

        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly UserManager<IdentityUser> _userManager;

        public AuthController(SignInManager<IdentityUser> signInManager, UserManager<IdentityUser> userManager)
        {
            _signInManager = signInManager;
            _userManager = userManager;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegisterUser register)
        {            
            var result = await _userManager.CreateAsync(register.ToIdentityUser(),register.Password);
            if(!result.Succeeded) return BadRequest(result.Errors);
            await _signInManager.SignInAsync(register.ToIdentityUser(),false);
            return CreatedAtAction(nameof(Login),null);
        }        
        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginUser login)
        {
            var result = await _signInManager.PasswordSignInAsync(login.Email, login.Password, false, true);
            if (!result.Succeeded)
            {
                return BadRequest("Usuario ou senha invalidos");
            }
            return Ok();           
        }
    }
}
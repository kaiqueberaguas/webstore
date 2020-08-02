using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using WebApi.src.models.authorizationModels;

namespace WebApi.src.controllers
{
    
    [Route("api/controller")]
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

        [HttpPost("RegisterUser")]
        public async Task<IActionResult> Register([FromBody] RegisterUser register)
        {
            if(!ModelState.IsValid) 
                return BadRequest(ModelState.Values.SelectMany(e => e.Errors));
            
            var result = await _userManager.CreateAsync(register.ToIdentityUser(),register.Password);
            if(!result.Succeeded) return BadRequest(result.Errors);
            
            return Created("/login",null);
        }        
    }
}
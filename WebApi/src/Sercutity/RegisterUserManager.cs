using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using webApi.src.Sercutity.AuthorizationModels;

namespace webApi.src.Sercutity
{
    public class RegisterUserManager
    {
        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly UserManager<IdentityUser> _userManager;

        public RegisterUserManager(SignInManager<IdentityUser> signInManager, UserManager<IdentityUser> userManager)
        {
            _signInManager = signInManager;
            _userManager = userManager;
        }

        public async Task<IdentityResult> Register(RegisterUser register)
        {
            RoleManager<Roles> roles = roles.CreateAsync(Roles.ROLE_CLIENTE);
            var result = await _userManager.CreateAsync(register.ToIdentityUser(), register.Password);
            await _userManager.AddToRoleAsync(register.ToIdentityUser(), );
            return result;
        }
    }
}

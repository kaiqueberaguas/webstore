using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace WebApi.src.Sercutity
{
    public class AdmintrationService : IAdmintrationService
    {

        private readonly UserManager<IdentityUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public AdmintrationService(UserManager<IdentityUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            _userManager = userManager;
            _roleManager = roleManager;
        }

        public async Task CreateRole(string role)
        {
            var result = new IdentityRole()
            {
                Name = role,
                NormalizedName = role.Normalize()
            };
            await _roleManager.CreateAsync(result);    
        }

        public async Task DeleteRole(string role)
        {
            if(_roleManager.RoleExistsAsync(role).Result)
            {
                var result = _roleManager.FindByNameAsync(role).Result;
                await _roleManager.DeleteAsync(result);    
            }
            else
            {
                throw new Exception("Role inexistente");
            }
        }

        public async Task UpdatePermission(UserAcess userAcess)
        {
            var exists = await _roleManager.RoleExistsAsync(userAcess.Role);
            var user = await _userManager.FindByNameAsync(userAcess.User);
            if(exists && user != null)
            {
                var roles = await _userManager.GetRolesAsync(user);
                if(roles.Contains(userAcess.Role))
                    await _userManager.RemoveFromRoleAsync(user,userAcess.Role);
                else
                    await _userManager.AddToRoleAsync(user,userAcess.Role);
            }
            else
            {
                throw new Exception("Usuario ou senha inexistente");
            }

        }
    }
}
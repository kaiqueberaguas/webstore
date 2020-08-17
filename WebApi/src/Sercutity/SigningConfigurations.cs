using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.Security.Cryptography;
using System.Text;

namespace webApi.src.Sercutity
{
    public class SigningConfigurations
    {
        
        public SecurityKey Key { get; }
        public SigningCredentials SigningCredentials { get; }

        private readonly IConfiguration _configuration;

        public SigningConfigurations(IConfiguration configuration)
        {
            _configuration = configuration;
            Key = new SymmetricSecurityKey(Encoding
                .ASCII.GetBytes(_configuration["JWT_KEY"]));
            SigningCredentials = new SigningCredentials(
                Key, SecurityAlgorithms.HmacSha256Signature);
                     
        }
    }
}

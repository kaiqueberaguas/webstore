using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace webApi.src.Sercutity.AuthorizationModels
{
    public class AccessCredentials
    {
        [Required(ErrorMessage = "campo obrigatorio")]
        [EmailAddress(ErrorMessage = "Formato invalido")]
        public string UserID { get; set; }

        [Required(ErrorMessage = "Campo obrigatorio")]
        [StringLength(10, ErrorMessage = "O campo {0} informado precisa ter entre {2} e {1} caracteres", MinimumLength = 8)]
        public string Password { get; set; }
        public string RefreshToken { get; set; }
        public string GrantType { get; set; }
    }
}

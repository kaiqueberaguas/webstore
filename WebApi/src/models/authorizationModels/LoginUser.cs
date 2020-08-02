using System.ComponentModel.DataAnnotations;

namespace WebApi.src.models.authorizationModels
{
    public class LoginUser
    {
        [Required(ErrorMessage = "campo obrigatorio")]
        [EmailAddress(ErrorMessage = "Formato invalido")]
        public string Email { get; set; }
        
        [Required(ErrorMessage = "Campo obrigatorio")]
        [StringLength(10,ErrorMessage = "O campo {0} informado precisa ter entre {2} e {1} caracteres",MinimumLength=8)]
        public string Password { get; set; }

    }
}
//using System.ComponentModel.DataAnnotations;
//using Microsoft.AspNetCore.Identity;

//namespace webApi.src.Sercutity.AuthorizationModels
//{
//    public class RegisterUser
//    {
//        [Required(ErrorMessage = "campo obrigatorio")]
//        [EmailAddress(ErrorMessage = "Formato invalido")]
//        public string Email { get; set; }

//        [Required(ErrorMessage = "Campo obrigatorio")]
//        [StringLength(10, ErrorMessage = "O campo {0} informado precisa ter entre {2} e {1} caracteres", MinimumLength = 8)]
//        public string Password { get; set; }

//        [Required(ErrorMessage = "Campo obrigatorio")]
//        [Compare("Password", ErrorMessage = "As senhas não conferem")]
//        public string ConfirmPassword { get; set; }

//        public IdentityUser ToIdentityUser()
//        {
//            var user = new IdentityUser()
//            {
//                UserName = Email,
//                Email = Email,
//                EmailConfirmed = true //todo inserir validação via email
//            };
//            return user;
//        }

//    }
//}
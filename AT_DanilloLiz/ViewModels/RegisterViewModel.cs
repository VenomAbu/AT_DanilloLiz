using System.ComponentModel.DataAnnotations;

namespace AT_DanilloLiz.ViewModels
{
    public class RegisterViewModel
    {
        [EmailAddress]
        [Required]
        public string? Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string? Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirme a senha")]
        [Compare("Password", ErrorMessage = "As senhas não conferem")]
        public string? ConfirmPassword { get; set; }
    }
}

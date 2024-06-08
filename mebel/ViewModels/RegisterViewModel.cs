using System.ComponentModel.DataAnnotations;

namespace mebel.ViewModels
{
    public class RegisterViewModel
    {
        [Display(Name = "Adres e-mail")]
        [Required(ErrorMessage = "Adres e-mail jest wymagany")]
        public string EmailAddress { get; set; }
        [Display(Name = "Hasło")]
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [Display(Name = "Potwierdź hasło")]
        [Required(ErrorMessage = "Pole jest wymagane")]
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "Hasła nie są identyczne")]
        public string ConfirmPassword { get; set; }
    }
}

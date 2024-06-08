﻿using System.ComponentModel.DataAnnotations;

namespace mebel.ViewModels
{
    public class LoginViewModel
    {
        [Display(Name = "Adres e-mail")]
        [Required(ErrorMessage = "Adres e-mail jest wymagany")]
        public string EmailAddress { get; set; }
        [Display(Name = "Hasło")]
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}

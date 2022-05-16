using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MobileAPPMVC.ViewModels.Account
{
    public class RegistrationViewModel
    {
        [Required(ErrorMessage = "Email is mandatory")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Password is mandatory")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Compare("Password", ErrorMessage = "Pasword & Confirm Passwrod must match")]
        [DataType(DataType.Password)]
        public string ConfirmPassword { get; set; }

    }
}

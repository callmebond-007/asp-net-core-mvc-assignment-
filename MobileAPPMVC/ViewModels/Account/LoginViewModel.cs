using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MobileAPPMVC.ViewModels.Account
{
    public class LoginViewModel
    {
        [Required(ErrorMessage = "Email is mandatory")]

        [Display(Name = "User Name")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Password is mandatory")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

    }
}

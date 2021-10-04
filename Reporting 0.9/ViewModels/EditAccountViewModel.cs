using Reporting.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Reporting.ViewModels
{
    public class EditAccountViewModel : AppUser
    {

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = " Mot de Passe")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "Le mot de passe et le mot de passe de confirmation ne correspondent pas")]
        [Display(Name = "Confermer Le Mot de Passe")]
        public string ConfirmPassword { get; set; }
    }
}

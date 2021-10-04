using Microsoft.AspNetCore.Mvc;
using Reporting.Tools;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace Reporting.ViewModels
{
    public class AccountRegisterViewModel
    {
        [Required]
        [Display(Name = "Prénom")]
        public string Prenom { get; set; }
        [Required]
        [Display(Name = "Nom")]
        public string Nom { get; set; }
        [Required]
        [Display(Name = "Direction")]
        public string Direction { get; set; }
        [Required]
        [Display(Name = "Site")]
        public string Site { get; set; }
        [Required]
        [DataType(DataType.EmailAddress)]

        //[Remote(action: "CheckingExistingEmail", controller: "Account")]
       // [ValidEmailDomainAttribute(Domain: "gmail.com;hotmail.com;", ErrorMessage = "Le domaine de l'email doit être gmail.com ou hotmail.com")]
        public string Email { get; set; }
        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Mot de Passe")]
        public string Password { get; set; }
        [DataType(DataType.Password)]
        [Compare("Password",ErrorMessage = "Le mot de passe et le mot de passe de confirmation ne correspondent pas")]
        [Display(Name = "Confirmer le Mot de Passe")]
        public string ConfirmPassword { get; set; }

    }
}

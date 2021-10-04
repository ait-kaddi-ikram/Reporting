using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Reporting.Tools;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Reporting.ViewModels
{
    public class AccountLoginViewModel
    {
        [Required]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Mot De Passe")]
        public string Password { get; set; }
        [Display(Name = "Souvienez-vous de moi")]
        public Boolean Remember { get; set; }
        public string ReturnURL { get; set; }
        public IList<AuthenticationScheme> ExternalLogins { get; set; }
    }
}

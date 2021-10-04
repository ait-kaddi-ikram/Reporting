using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Reporting.ViewModels
{
    public class UsersViewModel
    {
        public string Id { get; set; }
        [Display(Name = "Prénom")]
        public string Prenom { get; set; }
        [Display(Name = "Nom")]
        public string Nom { get; set; }

        [Display(Name = "Direction")]
        public string Direction { get; set; }

        [Display(Name = "Site")]
        public string Site { get; set; }
        public string Email { get; set; }
    }
}

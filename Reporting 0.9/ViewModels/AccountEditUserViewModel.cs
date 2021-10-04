using Reporting.Tools;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Reporting.ViewModels
{
    public class AccountEditUserViewModel
    {
        public AccountEditUserViewModel()
        {
            Roles = new List<string>();
            Claims = new List<string>();
        }
        public string Id { get; set; }

        [Required]
        [Display(Name = "Prénom")]

        public string Prenom { get; set; }

        [Required]
        [Display(Name = "Nom")]

        public string Nom { get; set; }
        [Required]
        [Display(Name = "Site")]

        public string Site { get; set; }
        [Required]
        [Display(Name = "Direction")]

        public string Direction { get; set; }

        [Required]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        public IList<string> Roles { get; set; }
        public IList<string> Claims { get; set; }
    }
      
}

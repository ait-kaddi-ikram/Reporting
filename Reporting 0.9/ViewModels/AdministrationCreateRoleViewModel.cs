using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Reporting.ViewModels
{
    public class AdministrationCreateRoleViewModel
    {   
        [Required]
        [Display(Name = "Enter Le Nom")]
        public string RoleName { get; set; }
    }
}

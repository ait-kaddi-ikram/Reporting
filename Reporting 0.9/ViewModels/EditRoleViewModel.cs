using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Reporting.ViewModels
{
    public class EditRoleViewModel
    {
        public string Id { get; set; }
        [Required(ErrorMessage = "Le Nom est obligatoire")]
        [Display(Name= "Enter le nouveau Nom :")]
        public string RoleName { get; set; }
        public List<string> Users {get; set; }
}
}

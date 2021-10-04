using FSharp.Data.Runtime.StructuralTypes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Reporting.Models
{
    public class Dop
    {
        public int Id { get; set; }
        
        public string Libele { get; set; }
        public Boolean ? IsSelected { get; set; }
        public virtual ICollection<ListeAgence> ListeAgence { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Reporting.Models
{
    public class ListeAgence
    {
        public int Id { get; set; }
        public string NOM { get; set; }
        public int Id_DOP { get; set; }

        [ForeignKey(nameof(Id_DOP))]
        public virtual Dop Dop { get; set; }
    }
}

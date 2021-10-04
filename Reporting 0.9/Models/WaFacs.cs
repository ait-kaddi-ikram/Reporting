using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace Reporting.Models
{
    public partial class WaFacs
    {
        public int Id { get; set; }
        public string DOP { get; set; }
        public int? NUMTRN { get; set; }
        public string AGCTRN { get; set; }
        public string LIBCATEG_ABT { get; set; }
        public int? CAT_ABT { get; set; }
        
        [DisplayFormat(ApplyFormatInEditMode =  true, DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime DAT_FACT { get; set; }
        public string TYP_FACT { get; set; }
        public string TYP_FACT_REF { get; set; }
        public string ETA_FACT { get; set; }
        
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}",  NullDisplayText = "No Date")]
        public DateTime? DAT_EXG_FACT { get; set; }
        public decimal MNT_FACT { get; set; }
        
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime DATE_MAJ { get; set; }
    }
}

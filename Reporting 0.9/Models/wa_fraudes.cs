using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Reporting.Models.Repositerie
{
    public class wa_fraudes
    {
       public int  ID { get; set; }
        public string DOP { get; set; }
        public int? ID_FAC_CLI { get; set; }
        public DateTime? DAT_FAC_CLI { get; set; }
        public DateTime? DAT_EXG_FAC_CLI { get; set; }
        public string TYP_FACT_ORI { get; set; }
        public int? NUM_CTA_ABT { get; set; }
        public int? NUM_TRN_RLV_ABT { get; set; }
        public string LIB_TRN { get; set; }
        public string LIB_CAT_ABT { get; set; }
        public int? NUM_CLI { get; set; }
        public string RAI_SOC_CLI { get; set; }
        public string PNO_CLI { get; set; }
        public string RPG_APT_PNT_DRT { get; set; }
        public string IG { get; set; }
        public string COORD_X { get; set; }
        public string COORD_Y { get; set; }
        public decimal MNT_FAC { get; set; }
        public string  LATI_LONG { get; set; }
        public decimal? MNT_AV { get; set; }
        public decimal? MNT_FAC_AV { get; set; }
        public decimal? QTE { get; set; }
        
    }
}

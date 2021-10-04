using ClosedXML.Excel;
using MailKit.Net.Smtp;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MimeKit;
using Newtonsoft.Json;
using Reporting.Models;
using Reporting.ViewModels;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reporting.Controllers
{
    [Authorize(Roles = "Clientele")]
    public class ClienteleController : Controller
    {
        private readonly ReportingContext _reportingContext;

        public static List<FactureViewModel> list;
        public ClienteleController(ReportingContext reportingContext)
        {
            _reportingContext = reportingContext;
        }
        public string getByIdDop(string Id)
        {
            var Query = (from X in _reportingContext.Dop.Where(x => x.Id == Convert.ToInt32(Id)) select X);
            return ((string)Query.FirstOrDefault().Libele);
        }
        public string getByIdAgence(string Id)
        {
            var Query = (from X in _reportingContext.ListeAgence.Where(x => x.Id == Convert.ToInt32(Id)) select X);
            return ((string)Query.FirstOrDefault().NOM);
        }

        /* public JsonResult getAgenceById(int  Id)
          {
              List<ListeAgence> list = new List <ListeAgence>();
              list = _reportingContext.ListeAgence.Where(a => a.Dop.Id == Id).ToList();
              list.Insert(0, new ListeAgence { Id= 0 ,NOM=""}) ;
              return Json(new SelectList(list, "Id","NOM"));
          }*/
        [HttpPost]
        public JsonResult AutoComplete(string prefix)
        {
            var fac = (from x in _reportingContext.wa_cat_abt
                       where x.libcateg_abt.StartsWith(prefix)
                       select new
                       {
                           label = x.libcateg_abt,
                           val = x.ID,
                       }).ToList();
            return Json(fac);
        }


        public List<FactureViewModel> Filtrer(string Facsearch, string AgenceSearch, DateTime startDate, DateTime endDate, string lib, int Id)
        {
            string dop;
            var empQuery = from x in _reportingContext.WaFacs select x;
            if (Facsearch == null || Facsearch == "Tous")
            {
                dop = null;
            }
            else { dop = getByIdDop(Facsearch); }
            ViewData["selected"] = Facsearch;

            string Agence;

            if (AgenceSearch == null || AgenceSearch == string.Empty)
            {
                Agence = null;
            }
            else { Agence = getByIdAgence(AgenceSearch); }
            ViewData["IsSelected"] = AgenceSearch;

            decimal total = 0;

            ViewBag.Dop = _reportingContext.Dop.ToList();
            ViewBag.ListeAgence = _reportingContext.ListeAgence.ToList();



            if (string.IsNullOrEmpty(dop) && string.IsNullOrEmpty(Agence) && startDate == DateTime.MinValue && endDate == DateTime.MinValue)
            {
                ViewData["GetStart"] = "01/01/2021";
                ViewData["GetEnd"] = DateTime.Now.ToString("dd/MM/yyyy");
                ViewBag.total = total;
                //ViewBag.fac = empQuery.ToList().Take(0);
                var mo = new List<FactureViewModel>();
                foreach (var emp in empQuery)
                {
                    var factureViewModel = new FactureViewModel
                    {
                        Id = emp.Id,
                        MNT_FACT = emp.MNT_FACT,
                    };
                }

                list = mo;
                return mo;
            }
            if (!string.IsNullOrEmpty(lib))
            {
                empQuery = empQuery.Where(x => x.LIBCATEG_ABT == lib);
            }

            if (!string.IsNullOrEmpty(dop))
            {
                empQuery = empQuery.Where(x => x.DOP == dop);
            }
            if (!string.IsNullOrEmpty(Agence))
            {
                empQuery = empQuery.Where(x => x.AGCTRN == Agence);
            }
            empQuery = empQuery.Where(x => (x.DAT_FACT >= startDate && x.DAT_FACT <= endDate));

            ViewData["GetStart"] = startDate.ToString("dd/MM/yyyy");
            ViewData["GetEnd"] = endDate.ToString("dd/MM/yyyy");
            ViewData["lib"] = lib;
            foreach (var item in empQuery)
            {
                total += item.MNT_FACT;
            }
            ViewBag.total = total;

            var model = new List<FactureViewModel>();
            foreach (var emp in empQuery.ToList())
            {
                var factureViewModel = new FactureViewModel
                {
                    Id = emp.Id,
                    DOP = emp.DOP,
                    NUMTRN = emp.NUMTRN,
                    AGCTRN = emp.AGCTRN,
                    LIBCATEG_ABT = emp.LIBCATEG_ABT,
                    CAT_ABT = emp.CAT_ABT,
                    DAT_FACT = emp.DAT_FACT,
                    TYP_FACT = emp.TYP_FACT,
                    TYP_FACT_REF = emp.TYP_FACT_REF,
                    ETA_FACT = emp.ETA_FACT,
                    DAT_EXG_FACT = emp.DAT_EXG_FACT,
                    MNT_FACT = emp.MNT_FACT,
                    DATE_MAJ = emp.DATE_MAJ,
                };
                model.Add(factureViewModel);
            }
            list = model;
            return model;
        }

        [HttpPost] [HttpGet]
        public IActionResult Facturation(string Facsearch, string AgenceSearch, DateTime startDate, DateTime endDate, string lib, int Id)
        {
            List<FactureViewModel> model;
            model = Filtrer(Facsearch, AgenceSearch, startDate, endDate, lib, Id);
            return View(model);

        }

        [HttpPost]
        [HttpGet]
        public IActionResult Export_fact(string Facsearch, string AgenceSearch, DateTime startDate, DateTime endDate, string lib, int Id)
        {
            List<FactureViewModel> list;
            list = Filtrer(Facsearch, AgenceSearch, startDate, endDate, lib, Id);
            using (var workbook = new XLWorkbook())
            {
                var worksheet = workbook.Worksheets.Add("list");
                var currentRow = 1;

                worksheet.Cell(currentRow, 1).Value = "DOP";
                worksheet.Cell(currentRow, 2).Value = "NUMTRN";
                worksheet.Cell(currentRow, 3).Value = "AGCTRN";
                worksheet.Cell(currentRow, 4).Value = "LIBCATEG_ABT";
                worksheet.Cell(currentRow, 5).Value = "CAT_ABT";
                worksheet.Cell(currentRow, 6).Value = "DAT_FACT";
                worksheet.Cell(currentRow, 7).Value = "TYP_FACT";
                worksheet.Cell(currentRow, 8).Value = "TYP_FACT_REF";
                worksheet.Cell(currentRow, 9).Value = "ETA_FACT";
                worksheet.Cell(currentRow, 10).Value = "DAT_EXG_FACT";
                worksheet.Cell(currentRow, 11).Value = "MNT_FACT";
                worksheet.Cell(currentRow, 12).Value = "DATE_MAJ";

                foreach (var fac in list)
                {
                    currentRow++;

                    worksheet.Cell(currentRow, 1).Value = fac.DOP;
                    worksheet.Cell(currentRow, 2).Value = fac.NUMTRN;
                    worksheet.Cell(currentRow, 3).Value = fac.AGCTRN;
                    worksheet.Cell(currentRow, 4).Value = fac.LIBCATEG_ABT;
                    worksheet.Cell(currentRow, 5).Value = fac.CAT_ABT;
                    worksheet.Cell(currentRow, 6).SetValue<string>(Convert.ToString(fac.DAT_FACT));
                    worksheet.Cell(currentRow, 7).Value = fac.TYP_FACT;
                    worksheet.Cell(currentRow, 8).Value = fac.TYP_FACT_REF;
                    worksheet.Cell(currentRow, 9).Value = fac.ETA_FACT;
                    worksheet.Cell(currentRow, 10).SetValue<string>(Convert.ToString(fac.DAT_EXG_FACT));
                    worksheet.Cell(currentRow, 11).Value = fac.MNT_FACT;
                    worksheet.Cell(currentRow, 12).SetValue<string>(Convert.ToString(fac.DATE_MAJ));

                }
                using (var stream = new MemoryStream())
                {
                    workbook.SaveAs(stream);
                    var content = stream.ToArray();
                    return File(content, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet",
                        "wafacs.xlsx");
                }
            }
        }
        public List<FraudesViewModel> Filtrer_Fraudes(DateTime startDate, DateTime endDate, string numCtaAbt, string numCli)
        {
            var empQuery = from x in _reportingContext.wa_fraudes select x;
            decimal total = 0;

            if (string.IsNullOrEmpty(numCtaAbt) && string.IsNullOrEmpty(numCli) && startDate == DateTime.MinValue && endDate == DateTime.MinValue)
            {


                ViewData["GetStart"] = "01/01/2021";
                ViewData["GetEnd"] = DateTime.Now.ToString("dd/MM/yyyy");
                ViewBag.total = total;

                List<FraudesViewModel> mo = new List<FraudesViewModel>();
                foreach (var emp in empQuery)
                {
                    var FraudesViewModel = new FraudesViewModel
                    {
                       
                    };
                    // mo.Add(FraudesViewModel);
                }


                return mo;
            }
            if (!string.IsNullOrEmpty(numCtaAbt))
            {
                empQuery = empQuery.Where(x => x.NUM_CTA_ABT == Convert.ToInt32(numCtaAbt));
            }

            if (!string.IsNullOrEmpty(numCli))
            {
                empQuery = empQuery.Where(x => x.NUM_CLI == Convert.ToInt32(numCli));
            }
         
            empQuery = empQuery.Where(x => (x.DAT_FAC_CLI >= startDate && x.DAT_FAC_CLI <= endDate));

            ViewData["GetStart"] = startDate.ToString("dd/MM/yyyy");
            ViewData["GetEnd"] = endDate.ToString("dd/MM/yyyy");
            ViewData["ctaAbt"] = numCtaAbt;
            ViewData["NumCli"] = numCli;

            foreach (var item in empQuery)
            {
                total += item.MNT_FAC;
            }
            ViewBag.total = total;
            List<FraudesViewModel> model = new List<FraudesViewModel>();
            foreach (var emp in empQuery)
            {
                var FraudesViewModel = new FraudesViewModel
                {
                    DOP = emp.DOP,
                    ID_FAC_CLI = emp.ID_FAC_CLI,
                    DAT_FAC_CLI = emp.DAT_FAC_CLI,
                    DAT_EXG_FAC_CLI = emp.DAT_EXG_FAC_CLI,
                    TYP_FACT_ORI = emp.TYP_FACT_ORI,
                    NUM_CTA_ABT = emp.NUM_CTA_ABT,
                    NUM_TRN_RLV_ABT = emp.NUM_TRN_RLV_ABT,
                    LIB_TRN = emp.LIB_TRN,
                    LIB_CAT_ABT = emp.LIB_CAT_ABT,
                    NUM_CLI = emp.NUM_CLI,
                    RAI_SOC_CLI = emp.RAI_SOC_CLI,
                    PNO_CLI = emp.PNO_CLI,
                    RPG_APT_PNT_DRT = emp.RPG_APT_PNT_DRT,
                    IG = emp.IG,
                    COORD_X = emp.COORD_X,
                    COORD_Y = emp.COORD_Y,
                    MNT_FAC = emp.MNT_FAC,
                    LATI_LONG = emp.LATI_LONG,
                    MNT_AV = emp.MNT_AV,
                    MNT_FAC_AV = emp.MNT_FAC_AV,
                    QTE = emp.QTE,
                };
                model.Add(FraudesViewModel);
            }
            return model;
        }

        [HttpGet]
        [HttpPost]

        public IActionResult Fraudes(DateTime startDate, DateTime endDate, string numCtaAbt, string numCli)
        {
            List<FraudesViewModel> mo;
            mo = Filtrer_Fraudes(startDate, endDate,  numCtaAbt,numCli);
            return View(mo);
        }

       

        [HttpGet]
       
        public JsonResult FactureChart()
        {
            decimal total ;
            var rq = (from x in _reportingContext.Dop select x);
            List<DopMontantViewModel> model = new List<DopMontantViewModel>();
            foreach (var i in rq)
            {
                total = 0;
                var Query = (from x in list select x);
                Query = Query.Where(x => x.DOP == i.Libele);
                foreach (var emp in Query)
                {
                    total += emp.MNT_FACT;
                    
                }
                var DopMontantViewModel = new DopMontantViewModel
                {
                    DOP = i.Libele,
                    MNT_FACT_TOTAL = total,

                };
                model.Add(DopMontantViewModel);
            }
                
                return Json(model.ToList());
            }

        [HttpGet]
        public JsonResult AgenceChart()
        {
            decimal total;
            int p = 0;
            var rq = (from x in _reportingContext.ListeAgence select x);
            List<AgenceMontantViewModel> model = new List<AgenceMontantViewModel>();
            foreach (var i in rq)
            {
                p++;
                total = 0;
                var Query = (from x in list select x);
                Query = Query.Where(x => x.AGCTRN == i.NOM);
               /* if (p <= 10)
                {*/
                    foreach (var emp in Query)
                {
                    total += emp.MNT_FACT;

                }
                    
                        var AgenceMontantViewModel = new AgenceMontantViewModel
                        {
                            agence = i.NOM,
                            MNT_FACT_TOTAL = total,

                        };
                        model.Add(AgenceMontantViewModel);
                    
               // }
            }

            return Json(model.ToList());
        }

        public IActionResult Export_fraudes(DateTime startDate, DateTime endDate, string numCtaAbt, string numCli)
        {
            List<FraudesViewModel> list;
            list = Filtrer_Fraudes( startDate, endDate,  numCtaAbt, numCli);
            using (var workbook = new XLWorkbook())
            {
                var worksheet = workbook.Worksheets.Add("list");
                var currentRow = 1;

                worksheet.Cell(currentRow, 1).Value = "DOP";
                worksheet.Cell(currentRow, 2).Value = " ID_FAC_CLI";
                worksheet.Cell(currentRow, 3).Value = "DAT_FAC_CLI";
                worksheet.Cell(currentRow, 4).Value = "DAT_EXG_FAC_CLI";
                worksheet.Cell(currentRow, 5).Value = "TYP_FACT_ORI";
                worksheet.Cell(currentRow, 6).Value = "NUM_CTA_ABT";
                worksheet.Cell(currentRow, 7).Value = "NUM_TRN_RLV_ABT";
                worksheet.Cell(currentRow, 8).Value = "LIB_TRN";
                worksheet.Cell(currentRow, 9).Value = " LIB_CAT_ABT";
                worksheet.Cell(currentRow, 10).Value = "NUM_CLI";
                worksheet.Cell(currentRow, 11).Value = "RAI_SOC_CLI";
                worksheet.Cell(currentRow, 12).Value = "PNO_CLI";
                worksheet.Cell(currentRow, 13).Value = "RPG_APT_PNT_DRT";
                worksheet.Cell(currentRow, 14).Value = "COORD_X";
                worksheet.Cell(currentRow, 15).Value = "COORD_Y";
                worksheet.Cell(currentRow, 16).Value = "MNT_FAC";
                worksheet.Cell(currentRow, 17).Value = "LATI_LONG";
                worksheet.Cell(currentRow, 18).Value = "MNT_AV";
                worksheet.Cell(currentRow, 19).Value = "MNT_FAC_AV";
                worksheet.Cell(currentRow, 20).Value = "QTE";
                foreach (var fac in list)
                {
                    currentRow++;

                    worksheet.Cell(currentRow, 1).Value = fac.DOP;
                    worksheet.Cell(currentRow, 2).SetValue<string>(Convert.ToString(fac.ID_FAC_CLI));
                    worksheet.Cell(currentRow, 3).SetValue<string>(Convert.ToString(fac.DAT_FAC_CLI));
                    worksheet.Cell(currentRow, 4).SetValue<string>(Convert.ToString(fac.DAT_EXG_FAC_CLI));
                    worksheet.Cell(currentRow, 5).Value = fac.TYP_FACT_ORI;
                    worksheet.Cell(currentRow, 6).Value = fac.NUM_CTA_ABT;
                    worksheet.Cell(currentRow, 7).Value = fac.NUM_TRN_RLV_ABT;
                    worksheet.Cell(currentRow, 8).Value = fac.LIB_TRN;
                    worksheet.Cell(currentRow, 9).Value = fac.LIB_CAT_ABT;
                    worksheet.Cell(currentRow, 10).Value= fac.NUM_CLI;
                    worksheet.Cell(currentRow, 11).Value = fac.RAI_SOC_CLI;
                    worksheet.Cell(currentRow, 12).Value = fac.PNO_CLI;
                    worksheet.Cell(currentRow, 13).Value = fac.RPG_APT_PNT_DRT;
                    worksheet.Cell(currentRow, 14).Value = fac.COORD_X;
                    worksheet.Cell(currentRow, 15).Value = fac.COORD_Y;
                    worksheet.Cell(currentRow, 16).Value = fac.MNT_FAC;
                    worksheet.Cell(currentRow, 17).Value = fac.LATI_LONG;
                    worksheet.Cell(currentRow, 18).Value = fac.MNT_AV;
                    worksheet.Cell(currentRow, 19).Value = fac.MNT_FAC_AV;
                    worksheet.Cell(currentRow, 20).Value = fac.QTE;

                }
                using (var stream = new MemoryStream())
                {
                    workbook.SaveAs(stream);
                    var content = stream.ToArray();
                    return File(content, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet",
                        "fraudes.xlsx");
                }
            }
        }
    
        public IActionResult Index()
        {
           
            return View();
        }
    }
}

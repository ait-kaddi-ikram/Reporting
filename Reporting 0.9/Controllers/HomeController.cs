using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Reporting.Models;
using Reporting.ViewModels;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace Reporting.Controllers
{
    public class HomeController : Controller
    {
        private readonly ReportingContext _reportingContext;

        public HomeController(ReportingContext reportingContext)
        {
            _reportingContext = reportingContext;
        }
       
        public IActionResult Index()
        {
            var empQuery = from x in _reportingContext.WaFacs select x;
            decimal totalMontant = 0;
            decimal totalFac = 0;
            foreach (var item in empQuery)
            {
                totalMontant += item.MNT_FACT;
                totalFac++;

            }
            totalMontant = totalMontant / 1000000;
            ViewBag.totalMontant = Math.Round(totalMontant, 1 );
            ViewBag.totalFac = totalFac;
            var Query = from x in _reportingContext.wa_fraudes select x;
            decimal totalMFraudes = 0;
            decimal totalFraudes = 0;
            foreach (var item in Query)
            {
                totalMFraudes += item.MNT_FAC;
                totalFraudes++;

            }
            totalMFraudes = totalMFraudes / 1000000;
            ViewBag.totalMFraudes = Math.Round(totalMFraudes, 1);
            ViewBag.totalFraudes = totalFraudes;

            int i = 0;
            List<FraudesViewModel> mo = new List<FraudesViewModel>();
            var Quer = (from x in _reportingContext.wa_fraudes orderby x.MNT_FAC descending select x);
            foreach (var emp in Quer)
            {
                i++;
                if (i <= 10)
                {
                    var FraudesViewModel = new FraudesViewModel
                    {
                        NUM_CLI = emp.NUM_CLI,
                        MNT_FAC = emp.MNT_FAC
                    };
                    mo.Add(FraudesViewModel);
                }
            }
            return View(mo);
          
        }
      
       

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
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
                var Query = (from x in _reportingContext.WaFacs select x);
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

        public JsonResult FraudesChart()
        {
            decimal total;
            var rq = (from x in _reportingContext.Dop select x);
            List<DopMontantViewModel> model = new List<DopMontantViewModel>();
            foreach (var i in rq)
            {
                total = 0;
                var Query = (from x in _reportingContext.wa_fraudes select x);
                Query = Query.Where(x => x.DOP == i.Libele);
                foreach (var emp in Query)
                {
                    total += emp.MNT_FAC;

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
   
       

     
    }
}

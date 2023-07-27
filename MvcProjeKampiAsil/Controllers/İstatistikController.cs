using DataAccessLayer.Concrete;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcProjeKampiAsil.Controllers
{
    public class İstatistikController : Controller
    {
        // GET: İstatistik
        Context c=new Context();

        public ActionResult Index()
        {
            ViewBag.kategorisayisi = c.Categories.Count();

            ViewBag.YazılımSayisi=c.Headings.Where(p=>p.CategoryID==5).Count();  //yazilim kategorisi 5 numarali id ile kayıtlı

            //ViewBag.AharfiGecenYazarSayisi = c.Writers.

            ViewBag.EnFazlaBasligaSahipKategori= c.Headings
            .GroupBy(p => p.CategoryID) 
            .OrderByDescending(g => g.Count()) 
            .Select(g => g.Key) 
            .FirstOrDefault(); 

            ViewBag.Aharfigecensutunsayisi = c.Writers
            .Where(y => y.WriterName.Contains("a")) 
            .Count(); 

            int sttrue=c.Categories.Count(c=>c.CategoryStatus==true);

            int stfalse=c.Categories.Count(c=>c.CategoryStatus==false);

            int fark=sttrue-stfalse;
            ViewBag.TrueFalseFarki = fark;
    



            return View();
        }
        



    }
}
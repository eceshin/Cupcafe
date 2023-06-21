using Cupcafe.Service.Data;
using Cupcafe.Service.Models;
using CupCafe.Service.Core;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Cupcafe.Controllers
{
    public class KullaniciIslemController : Controller
    {

        CafeDbContext db = new CafeDbContext();
        public IActionResult Index()
        {
            return View();
        }

        private readonly KullaniciUrunService _kurunService;
        public KullaniciIslemController(KullaniciUrunService kullanicirunService)
        {
            _kurunService = kullanicirunService;
        }



        [HttpGet]
        public IActionResult IslemSayfa()
        {
            List<SelectListItem> degerkisi = (from i in db.Kullanicilar.ToList()
                                              select new SelectListItem
                                              {
                                                  Text = i.Email,
                                                  Value = i.Id.ToString()
                                              }).ToList();

            ViewBag.dgr1 = degerkisi;
            List<SelectListItem> degerUrun = (from i in db.Urunler.ToList()
                                              select new SelectListItem
                                              {
                                                  Text = i.Adi,
                                                  Value = i.Id.ToString()
                                              }).ToList();

            ViewBag.dgr2 = degerUrun;
            List<SelectListItem> degerIslem = (from i in db.Islemler.ToList()
                                               select new SelectListItem
                                               {
                                                   Text = i.IslemAdi,
                                                   Value = i.Id.ToString()
                                               }).ToList();

            ViewBag.dgr3 = degerIslem;

            return View();
        }




        [HttpPost]
        public IActionResult IslemSayfa(KullaniciUrun kullaniciUrun)
        {
            
            _kurunService.Save(kullaniciUrun);
            return RedirectToAction("Menu","Menu");
        }



    }
}

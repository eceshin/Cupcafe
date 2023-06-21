using Cupcafe.Service.Data;
using Cupcafe.Service.Models;
using Microsoft.AspNetCore.Mvc;
using CupCafe.Service.Core;

namespace Cupcafe.Controllers
{
    public class AnaSayfaController : Controller
    {


        private readonly AnaSayfaService _anaSayfaService;
        public AnaSayfaController(AnaSayfaService anaSayfaService)
        {
            _anaSayfaService = anaSayfaService;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult AnaSayfa()
        {
            return View();
        }


           public IActionResult KullaniciEkle(string email, string sifre)
            {
                _anaSayfaService.Save(email, sifre);
                return RedirectToAction("Menu", "Menu");
            }
       
    }
}

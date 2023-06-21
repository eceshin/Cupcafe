using Cupcafe.Service.Models;
using CupCafe.Service.Core;
using CupCafe.Service.DTO;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace Cupcafe.Controllers
{
    public class MenuController : ControllerBase
    {
        private readonly UrunService _urunService;
        public MenuController(UrunService urunService)
        {
            _urunService = urunService;
        }

       
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Menu()
        {
            var models = _urunService.GetAll();
            return View(models);
        }




        public IActionResult MenuSil(int id)
        {
            _urunService.Delete(id);
            return RedirectToAction("Menu");
        }


        
        public IActionResult MenuEkle(string adi, string fiyati, string foto)
        {
            _urunService.Save(adi,fiyati,foto);
            return RedirectToAction("Menu");
        }

        public IActionResult MenuGuncelle(int id, string adi, string fiyati, string foto)
        {
            _urunService.Update(id, adi, fiyati, foto);
            return RedirectToAction("Menu");
        }



    }
}

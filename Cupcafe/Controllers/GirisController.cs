using Cupcafe.Service.Data;
using Cupcafe.Service.Models;
using CupCafe.Service.Core;
using CupCafe.Service.DTO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Cupcafe.Controllers
{
    public class GirisController : Controller
    {
        private LoginService _loginService;

        public GirisController(LoginService loginService)
        {
            _loginService = loginService;
        }

        CafeDbContext db = new CafeDbContext();

        public SessionInfo UserSession
        {
            get
            {
                var value = HttpContext.Session.GetString("UserSessionInfo");
                return value == null ? default(SessionInfo) : JsonConvert.DeserializeObject<SessionInfo>(value);
            }

            set
            {
                var jsonString = JsonConvert.SerializeObject(value);
                HttpContext.Session.SetString("UserSessionInfo", jsonString);
            }
        }

        public IActionResult Index(int id)
        {
            return View();
        }

        [HttpGet]
        public IActionResult Login()
        {
            var viewModel = new LoginViewModel();
            return View(viewModel);
        }

        [HttpPost]
        public IActionResult Login(LoginViewModel viewModel)
        {
            var Kullanici = _loginService.CheckUser(viewModel);

            if (Kullanici != null)
            {
                UserSession = new SessionInfo
                {
                    UserId = Kullanici.Id,
                    UserEmail = Kullanici.Email,
                    UserSifre = Kullanici.Sifre
                };

                ViewBag.Email = UserSession.UserEmail;
                return RedirectToAction("Menu", "Menu");
            }
            else
            {
                TempData["error"] = "Hata Oluştu";
                return View();
            }
        }
    }
}

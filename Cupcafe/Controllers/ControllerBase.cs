using CupCafe.Service.DTO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Diagnostics;
using Microsoft.AspNetCore.Mvc.Filters;
using Newtonsoft.Json;

namespace Cupcafe.Controllers
{
    public class ControllerBase : Controller
    {
        public SessionInfo CurrentSession
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

        public bool IsSessionAlive { get
            {
                return CurrentSession != null;
            } }

        public override void OnActionExecuted(ActionExecutedContext filtercontext)
        {
            if (IsSessionAlive == false)
            {
                filtercontext.Result = RedirectToLoginPage();
                return;

            }
            base.OnActionExecuted(filtercontext);
        }

        private IActionResult? RedirectToLoginPage(string redirectAction="Login")
        {
            return RedirectToAction("Login", "Giris");
        }
    }
}

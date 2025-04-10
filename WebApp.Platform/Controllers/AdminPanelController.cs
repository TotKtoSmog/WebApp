using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WebApp.Platform.Controllers
{
    [Authorize(Roles="Admin")]
    public class AdminPanelController : Controller
    {
        public IActionResult Index() => View();
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Logout()
        {
            Response.Cookies.Delete("jwt_token");
            return RedirectToAction("Authorization","User");
        }
    }
}

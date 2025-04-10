using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WebApp.Platform.Controllers
{
    [Authorize(Roles="Admin")]
    public class AdminPanelController : Controller
    {
        public IActionResult Index() => View();
    }
}

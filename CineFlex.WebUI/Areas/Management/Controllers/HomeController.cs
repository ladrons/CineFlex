using Microsoft.AspNetCore.Mvc;

namespace CineFlex.WebUI.Areas.Management.Controllers
{
    [Area("Management")]
    [Route("Management/[controller]")]
    public class HomeController : Controller
    {
        [Route("Dashboard")]
        public IActionResult Dashboard()
        {
            return View();
        }

        [Route("Error")]
        public IActionResult Error()
        {
            ViewBag.ErrorMessage = TempData["ErrorMessage"];
            return View();
        }
    }
}
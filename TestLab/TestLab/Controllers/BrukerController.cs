using Microsoft.AspNetCore.Mvc;

namespace TestLab.Controllers
{
    public class BrukerController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}

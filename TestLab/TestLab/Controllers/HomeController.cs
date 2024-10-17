using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using TestLab.Models;

namespace TestLab.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        private static List<PositionModel> positions = new List<PositionModel>();

        private static List<AreaChange> changes = new List<AreaChange>();
        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult RegisterAreaChange()
        {
            return View();
        }

        [HttpPost]
        public IActionResult RegisterAreaChange(string geoJson, string description)
        {
            var newchange = new AreaChange
            {
                Id = Guid.NewGuid().ToString(),
                GeoJson = geoJson,
                Description = description
            };
            changes.Add(newchange);
            return RedirectToAction("AreaChangeOverview");  
        }

        [HttpGet]
        public IActionResult AreaChangeOverview()
        {
            return View(changes);
        }

        [HttpGet]
        public ViewResult RegistrationForm()
        {
            return View();
        }

        [HttpPost]
        public ViewResult RegistrationForm(UserData userData)
        {
            return View("Overview", userData);
        }

        [HttpGet]
        public IActionResult CorrectMap()
        {
            return View();
        }

        [HttpPost]
        public IActionResult CorrectMap(PositionModel model)
        {
            if (ModelState.IsValid)
            {
                positions.Add(model);

                return View("CorrectionOverview", positions);
            }
            return View();
        }

        [HttpGet]
        public IActionResult CorrectOverview()
        {
            return View(positions);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}

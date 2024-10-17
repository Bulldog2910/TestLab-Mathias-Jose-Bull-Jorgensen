using Microsoft.AspNetCore.Mvc;
using TestLab.Models;

namespace TestLab.Controllers
{
    public class PositionController : Controller // Use a meaningful name
    {
        [HttpPost]
        public IActionResult CorrectMap(PositionModel model)
        {
            // Process the model as needed

            // Redirect to CorrectOverview
            return RedirectToAction("CorrectOverview");
        }

        public IActionResult CorrectOverview()
        {
            return View();
        }
    }
}

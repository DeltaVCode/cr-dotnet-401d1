using Demo.Web.Models;
using Microsoft.AspNetCore.Mvc;

namespace Demo.Web.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        // request.params.value1
        [HttpPost]
        public IActionResult Index(int value1, int value2)
        {
            // Don't show View() directly in a POST; redirect instead
            // return View();

            // Post - Redirect - Get
            return RedirectToAction("Adder", new { value1, value2 });
        }

        // Model binding of all the applicable properties in the model type
        public IActionResult Adder(AdderViewModel viewModel)
        {
            return View(viewModel);
        }

        public IActionResult Welcome()
        {
            // render Views/Home/Welcome.cshtml
            return View();
        }
    }
}

using System.Collections.Generic;
using Demo.Web.Models;
using Microsoft.AspNetCore.Mvc;

namespace Demo.Web.Controllers
{
    public class AboutController : Controller
    {
        public IActionResult Index()
        {
            // Return DeltaV staff

            // var viewModel = { list: staff }
            // response.render('pages/about', viewModel)

            List<Staff> staffList = new List<Staff>
            {
                new Staff { Name = "Keith", Role = Role.Instructor },
                new Staff { Name = "Craig", Role = Role.Instructor },
                new Staff { Name = "Aaron", Role = Role.Admin },
            };

            AboutViewModel viewModel = new AboutViewModel
            {
                CompanyName = "DeltaV Code School",
                Staff = staffList,
            };
            return View(viewModel);
        }
    }
}

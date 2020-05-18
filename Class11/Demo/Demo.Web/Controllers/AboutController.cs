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

            List<Staff> staffList = Models.Staff.GetStaff();

            AboutViewModel viewModel = new AboutViewModel
            {
                CompanyName = "DeltaV Code School",
                Staff = staffList,
            };
            return View(viewModel);
        }

        public IActionResult ListStaff()
        {
            return View(Models.Staff.GetStaff());
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Demo.Controllers
{
    public class MvcReadWriteController : Controller
    {
        // GET: MvcReadWrite
        public ActionResult Index()
        {
            return View();
        }

        // GET: MvcReadWrite/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: MvcReadWrite/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: MvcReadWrite/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: MvcReadWrite/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: MvcReadWrite/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: MvcReadWrite/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: MvcReadWrite/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
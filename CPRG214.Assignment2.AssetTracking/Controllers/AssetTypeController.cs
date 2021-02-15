using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CPRG214.Assignment2.AssetTracking.Controllers
{
    public class AssetTypeController : Controller
    {
        // GET: AssetTypeController
        public ActionResult Index()
        {
            return View();
        }

        // GET: AssetTypeController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: AssetTypeController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: AssetTypeController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: AssetTypeController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: AssetTypeController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: AssetTypeController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: AssetTypeController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}

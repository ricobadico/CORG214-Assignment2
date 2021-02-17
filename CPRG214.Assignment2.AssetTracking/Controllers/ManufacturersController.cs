using CPRG214.Assignment2.BLL;
using CPRG214.Assignment2.Domain;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CPRG214.Assignment2.AssetTracking.Controllers
{
    public class ManufacturersController : Controller
    {
        // GET: AssetTypeController
        public ActionResult Index()
        {
            IList manufacturers = ManufacturerManager.GetAll();

            return View(manufacturers);
        }


        // GET: AssetTypeController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: AssetTypeController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Manufacturer newManufacturer)
        {
            try
            {
                ManufacturerManager.Add(newManufacturer.Name);
                return RedirectToAction(nameof(Index));
            }
            catch (ArgumentException ex)
            {
                ViewBag.UniqueConstraintError = ex.Message;
                return View();
            }
            catch
            {
                ViewBag.ErrorMessage = "There was an issue adding this entry to the database. Please try again or contact IT.";
                return View();
            }
        }
    }
}

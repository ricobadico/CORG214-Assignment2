using CPRG214.Assignment2.BLL;
using CPRG214.Assignment2.Domain;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CPRG214.Assignment2.AssetTracking.Controllers
{
    public class AssetTypesController : Controller
    {
        // GET: AssetTypeController
        public ActionResult Index()
        {
            IList assetTypes = AssetTypeManager.GetAll();

            return View(assetTypes);
        }


        // GET: AssetTypeController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: AssetTypeController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(AssetType newAssetType)
        {
            try
            {
                AssetTypeManager.Add(newAssetType);
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

using CPRG214.Assignment2.AssetTracking.Models;
using CPRG214.Assignment2.BLL;
using CPRG214.Assignment2.Domain;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CPRG214.Assignment2.AssetTracking.Controllers
{
    public class AssetsController : Controller
    {
        public IActionResult Index()
        {

            // Grab asset types in a dropdown for filtering
            IList assetTypes = AssetTypeManager.GetAsKeyValuePairs();
            // Convert to SelectList
           var assetList = new SelectList(assetTypes, "Key", "Value");
            // Add value for "All"
            var assetTypeDropdownList  = assetList.ToList();
            assetTypeDropdownList.Insert(0, new SelectListItem
            {
                Text = "All",
                Value = "0"
            });
            // Add to Viewbag
            ViewBag.AssetTypeList = assetTypeDropdownList;

            // Pass model to the view
            return View();
        }

        public IActionResult GetAssetsByType(int id)
        {
            return ViewComponent("AssetsByType", id);
        }

        // Action to get to Create page
        public IActionResult Create()
        {
            // Get lists of AssetTypes and Manufacturers
            IList assetTypes = AssetTypeManager.GetAsKeyValuePairs();
            IList manufacturers = ManufacturerManager.GetAsKeyValuePairs();

            // Convert the lists into SelectLists for dropdowns
            SelectList assetTypeDropdownList = new SelectList(assetTypes, "Key", "Value");
            SelectList manufacturerDropdownList = new SelectList(manufacturers, "Key", "Value");

            // Pass SelectLists into Viewbag for use in view
            ViewBag.AssetTypeList = assetTypeDropdownList;
            ViewBag.ManufacturerList = manufacturerDropdownList;
            ViewBag.ManufacturerListForJquery = JsonConvert.SerializeObject(manufacturerDropdownList);

            return View();
        }

        // Create() overload when posting back with a completed form, creating an Asset
        [HttpPost]
        public IActionResult Create(Asset asset)
        {
            IList manufacturers = ManufacturerManager.GetAsKeyValuePairs();
            SelectList manufacturerDropdownList = new SelectList(manufacturers, "Key", "Value");
            ViewBag.ManufacturerList = manufacturerDropdownList;


            try
            {
                // Add the new asset made by the user
                AssetManager.Add(asset);

                // Return to index page
                return RedirectToAction("Index");
            }
            catch
            {
                ViewBag.ErrorMessage = "There was an issue adding this entry to the database. Please try again or contact IT.";
                return View();
            }
        }

        [HttpPost]
        // Inserts a new manufacturer into the database
        public IActionResult AddManufacturer(string manufacturerType)
        {

            int newManufacturerID = ManufacturerManager.Add(manufacturerType);
            return Content(newManufacturerID.ToString());
 
        }
    }
}

using CPRG214.Assignment2.AssetTracking.Models;
using CPRG214.Assignment2.BLL;
using CPRG214.Assignment2.Domain;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Logging;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace CPRG214.Assignment2.AssetTracking.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            // Get list of assets from DB
            List<Asset> assets = AssetManager.GetAll();

            // Funnel that asset data into the asset viewmodel for display
            List<AssetViewModel> assetViewModels = assets.Select(asset => new AssetViewModel
            {
                Description = asset.Description,
                TypeName =  asset.AssetType.Name,
                TagNumber = asset.TagNumber,
                SerialNumber = asset.SerialNumber
            }
            ).ToList();

            // Pass model to the view
            return View(assetViewModels);
        }

        // Action to get to Create page
        public IActionResult Create()
        {
            // Get lists of AssetTypes and Manufacturers
            IList assetTypes = AssetTypeManager.GetAsKeyValuePairs();
            IList manufacturers = ManufacturerManager.GetAsKeyValuePairs();

            // Convert the lists into SelectLists for dropdowns
            SelectList assetDropdownList = new SelectList(assetTypes, "Key", "Value");
            SelectList manufacturerDropdownList = new SelectList(manufacturers, "Key", "Value");

            // Pass SelectLists into Viewbag for use in view
            ViewBag.AssetTypeList = assetDropdownList;
            ViewBag.ManufacturerList = manufacturerDropdownList;

            return View();
        }

        // Create() overload when posting back with a completed form, creating an Asset
        [HttpPost]
        public IActionResult Create(Asset asset)
        {
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

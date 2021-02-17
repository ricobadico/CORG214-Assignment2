using CPRG214.Assignment2.AssetTracking.Models;
using CPRG214.Assignment2.BLL;
using CPRG214.Assignment2.Domain;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CPRG214.Assignment2.AssetTracking.ViewComponents
{
    public class AssetsByType : ViewComponent
    {

        public async Task<IViewComponentResult> InvokeAsync(int assetID)
        {
            // Initialize a variable to hold the filtered assets
            List<Asset> assets = null;

            if(assetID == 0) // value given for our "All" option added to list of AssetTypes
            {
                // Get all assets
                assets = AssetManager.GetAll();
            }
            else
            {
                // Else get assets filtered by asset type
                assets = AssetManager.GetAssetsByAssetType(assetID);
            }

            // Take these assets and map them onto the viewmodel
            List<AssetViewModel> assetViewModels = assets.Select(asset => new AssetViewModel
            {
                Id = asset.Id,
                Description = asset.Description,
                TypeName = asset.AssetType.Name,
                TagNumber = asset.TagNumber,
                SerialNumber = asset.SerialNumber
            }
            ).ToList();

            return View(assetViewModels);
        }
    }
}

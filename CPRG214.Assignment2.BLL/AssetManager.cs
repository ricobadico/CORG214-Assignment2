using CPRG214.Assignment2.Data;
using CPRG214.Assignment2.Domain;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;

namespace CPRG214.Assignment2.BLL
{
    public class AssetManager
    {
        /// <summary>
        /// Returns a list of all Assets from the database.
        /// </summary>
        /// <returns>List of assets.</returns>
        public static List<Asset> GetAll()
        {
            // Connect to database
            AssetsContext db = new AssetsContext();

            // Grab list of all Assets, including navigation properties
            List<Asset> assets = db.Assets
                .Include(asset => asset.AssetType) // Navigation Property
                .Include(asset => asset.Manufacturer) // Navigation Property
                .ToList();

            return assets;
        }

        /// <summary>
        /// Inserts provided asset into the database.
        /// </summary>
        /// <param name="newAsset">The Asset object to be inserted.</param>
        public static void Add(Asset newAsset)
        {
            AssetsContext db = new AssetsContext();

            db.Assets.Add(newAsset);
            db.SaveChanges();
        }
    }
}

using CPRG214.Assignment2.Data;
using CPRG214.Assignment2.Domain;
using System;
using System.Collections;
using System.Linq;

namespace CPRG214.Assignment2.BLL
{
    public class AssetTypeManager
    {
        public static IList GetAll()
        {
            // Connect to db
            AssetsContext db = new AssetsContext();

            return db.AssetTypes.ToList();
        }

        public static IList GetAsKeyValuePairs()
        {
            // Connect to db
            AssetsContext db = new AssetsContext();

            // Project asset types into anonymous class of key value pairs
            IList assetTypes = db.AssetTypes.Select(at => new
            {
                Key = at.Id,
                Value = at.Name
            }).ToList();

            return assetTypes;
        }

        public static void Add(AssetType newAssetType)
        {
            AssetsContext db = new AssetsContext();
            
            // See if the new Asset's name already exists in the DB
            var existingName = db.AssetTypes.SingleOrDefault(at => at.Name == newAssetType.Name);

            if (existingName == null) // if that name is not in use yet
            {
                db.AssetTypes.Add(newAssetType);
                db.SaveChanges();
            }
            else
            {
                throw new ArgumentException($"The asset type {newAssetType.Name} already exists.");
            }

        }
    }
}

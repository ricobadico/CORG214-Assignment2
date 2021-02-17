using CPRG214.Assignment2.Data;
using CPRG214.Assignment2.Domain;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CPRG214.Assignment2.BLL
{
    public class ManufacturerManager
    {
        public static IList GetAsKeyValuePairs()
        {
            // Connect to db
            AssetsContext db = new AssetsContext();

            // Project manufacturers into anonymous class of key value pairs
            IList manufacturers = db.Manufacturers.Select(at => new
            {
                Key = at.Id,
                Value = at.Name
            }).OrderBy(at => at.Value) // order aphabetically
            .ToList();

            return manufacturers;
        }

        public static IList GetAll()
        {
            AssetsContext db = new AssetsContext();
            return db.Manufacturers.ToList();
        }

        /// <summary>
        /// Adds a new Manufacturer to the database, giving back the insert ID.
        /// </summary>
        /// <param name="manuName">Name for the manufacturer.</param>
        /// <returns>The ID for the inserted entry in the database.</returns>
        public static int Add(string manuName)
        {
            AssetsContext db = new AssetsContext();
            Manufacturer newManu = new Manufacturer
            {
                Name = manuName
            };

            // See if the new Asset's name already exists in the DB
            var existingName = db.AssetTypes.SingleOrDefault(at => at.Name == manuName);

            if (existingName == null) // if that name is not in use yet
            {
                db.Manufacturers.Add(newManu);
                db.SaveChanges();

                // After calling SaveChanges, we can get the insert ID straight from the object
                return newManu.Id;
            }
            else
            {
                throw new ArgumentException($"The asset type {manuName} already exists.");
            }
        }
    }
}

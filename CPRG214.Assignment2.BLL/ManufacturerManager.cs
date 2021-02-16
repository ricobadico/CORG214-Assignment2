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

            db.Manufacturers.Add(newManu);
            db.SaveChanges();

            // After calling SaveChanges, we can get the insert ID straight from the object
            return newManu.Id;
        }
    }
}

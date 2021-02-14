using CPRG214.Assignment2.Data;
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
    }
}

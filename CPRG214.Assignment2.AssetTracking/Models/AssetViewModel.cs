using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CPRG214.Assignment2.AssetTracking.Models
{
    public class AssetViewModel
    {
        public int Id { get; set; }

        public string  Description { get; set; }

        [Display(Name = "Asset Type")]
        public string TypeName { get; set; }

        [Display(Name = "Tag Number")]
        public string TagNumber { get; set; }

        [Display(Name = "Serial Number")]
        public string SerialNumber { get; set; }
    }
}

using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CPRG214.Assignment2.Domain
{
    [Table("Asset")]
    public class Asset
    {
        public int Id { get; set; }

        [Required]
        public string TagNumber { get; set; }

        public int AssetTypeId { get; set; }

        public int ManufacturerId { get; set; }

        public string Model { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        [Display(Name = "Serial Number")]
        public string SerialNumber { get; set; }

        // Navigation property
        public AssetType AssetType { get; set; }
        public Manufacturer Manufacturer { get; set; }
    }
}

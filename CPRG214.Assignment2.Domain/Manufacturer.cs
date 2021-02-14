using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace CPRG214.Assignment2.Domain
{
    [Table("Manufacturer")]
    public class Manufacturer
    {
        public int Id { get; set; }
        [Required]
        [Display(Name = "Manufacturer")]
        public string Name { get; set; }

        // Navigation property
        public ICollection<Asset> Assets { get; set; }
    }
}

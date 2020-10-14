using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Product.FrontEnd.Models
{
    public class ProductModel
    {
        public Guid ProductIdentity { get; set; }

        [Required]
        [StringLength(maximumLength: 50)]
        public String ProductName { get; set; }

        [Required]
        [Range(minimum: 100, maximum: 500)]
        public double? UnitPrice { get; set; }
    }
}
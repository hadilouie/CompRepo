using Comp.ProductManagement.Domain.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Comp.ProductManagement.Domain
{
    public class Product : BaseDomainEntity
    {
        [StringLength(50)]
        public string? ProductName { get; set; }
        public decimal Price { get; set; }
        [StringLength(500)]
        public string? ProductDescription { get; set; }
    }
}

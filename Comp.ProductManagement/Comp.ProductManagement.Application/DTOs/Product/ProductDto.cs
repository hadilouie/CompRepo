using Comp.ProductManagement.Application.DTOs.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace Comp.ProductManagement.Application.DTOs.Product
{
    public class ProductDto : BaseDto
    {
        public string? ProductName { get; set; }
        public decimal Price { get; set; }
        public string? ProductDescription { get; set; }
    }
}

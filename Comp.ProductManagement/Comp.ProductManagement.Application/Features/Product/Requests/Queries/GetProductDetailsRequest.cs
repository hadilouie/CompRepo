using Comp.ProductManagement.Application.DTOs.Product;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Comp.ProductManagement.Application.Features.Product.Requests.Queries
{
    public class GetProductDetailsRequest : IRequest<ProductDto>
    {
        public int Id { get; set; }
    }
}

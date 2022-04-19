using Comp.ProductManagement.Application.DTOs.Product;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Comp.ProductManagement.Application.Features.Product.Requests.Queries
{
    public class GetProductListRequest : IRequest<List<ProductDto>>
    {
    }
}

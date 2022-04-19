using Comp.ProductManagement.Application.DTOs.Product;

using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Comp.ProductManagement.Application.Features.Product.Requests.Commands
{
    public class UpdateProductCommand : IRequest<Unit>
    {
        public UpdateProductDto ProductDto { get; set; }
    }
}

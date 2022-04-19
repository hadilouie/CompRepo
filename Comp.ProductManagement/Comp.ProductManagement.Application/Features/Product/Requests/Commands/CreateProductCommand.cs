using Comp.ProductManagement.Application.DTOs.Product;
using Comp.ProductManagement.Application.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Comp.ProductManagement.Application.Features.Product.Requests.Commands
{
    public class CreateProductCommand : IRequest<BaseCommandResponse>
    {
        public CreateProductDto ProductDto { get; set; }
    }
}

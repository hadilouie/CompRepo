using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Comp.ProductManagement.Application.Features.Product.Requests.Commands
{
    public class DeleteProductCommand : IRequest
    {
        public int Id { get; set; }
    }
}

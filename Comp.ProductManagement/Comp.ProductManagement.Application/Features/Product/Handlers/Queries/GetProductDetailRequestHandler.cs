using AutoMapper;
using Comp.ProductManagement.Application.Contracts.Persistence;
using Comp.ProductManagement.Application.DTOs.Product;
using Comp.ProductManagement.Application.Exceptions;
using Comp.ProductManagement.Application.Features.Product.Requests.Queries;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Comp.ProductManagement.Application.Features.Product.Handlers.Queries
{
    public class GetProductDetailRequestHandler : IRequestHandler<GetProductDetailsRequest, ProductDto>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetProductDetailRequestHandler(
            IUnitOfWork unitOfWork,
            IMapper mapper)
        {
            this._unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<ProductDto> Handle(GetProductDetailsRequest request, CancellationToken cancellationToken)
        {
            var product = await _unitOfWork.ProductRepository.Get(request.Id);

            if (product == null)
                throw new NotFoundException(nameof(product), request.Id);

            return _mapper.Map<ProductDto>(product);
        }
    }
}

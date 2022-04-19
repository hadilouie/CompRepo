using AutoMapper;
using Comp.ProductManagement.Application.Contracts.Persistence;
using Comp.ProductManagement.Application.Exceptions;
using Comp.ProductManagement.Application.Features.Product.Requests.Commands;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Comp.ProductManagement.Application.Features.Product.Handlers.Commands
{
    public class DeleteProductRequestHandler : IRequestHandler<DeleteProductCommand>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public DeleteProductRequestHandler(
            IUnitOfWork unitOfWork,
            IMapper mapper)
        {
            this._unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(DeleteProductCommand request, CancellationToken cancellationToken)
        {
            var product = await _unitOfWork.ProductRepository.Get(request.Id);

            if (product == null)
                throw new NotFoundException(nameof(product), request.Id);

            await _unitOfWork.ProductRepository.Delete(product);
            await _unitOfWork.Save();
            return Unit.Value;
        }
    }
}

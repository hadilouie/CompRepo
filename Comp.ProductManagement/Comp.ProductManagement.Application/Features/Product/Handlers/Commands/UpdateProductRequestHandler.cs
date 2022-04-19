using AutoMapper;
using Comp.ProductManagement.Application.Contracts.Persistence;
using Comp.ProductManagement.Application.DTOs.Product.Validator;
using Comp.ProductManagement.Application.Exceptions;
using Comp.ProductManagement.Application.Features.Product.Requests.Commands;
using Comp.ProductManagement.Application.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Comp.ProductManagement.Application.Features.Product.Handlers.Commands
{
    public class UpdateProductRequestHandler : IRequestHandler<UpdateProductCommand, Unit>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public UpdateProductRequestHandler(
            IUnitOfWork unitOfWork,
            IMapper mapper)
        {
            this._unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<Unit> Handle(UpdateProductCommand request, CancellationToken cancellationToken)
        {
            var validator = new UpdateProductDtoValidator();
            var validationResult = await validator.ValidateAsync(request.ProductDto);

            if (validationResult.IsValid == false)
                throw new ValidationException(validationResult);

            var product = await _unitOfWork.ProductRepository.Get(request.ProductDto.Id);

            if (product == null)
                throw new NotFoundException(nameof(product), request.ProductDto.Id);

            _mapper.Map(request.ProductDto, product);

            await _unitOfWork.ProductRepository.Update(product);
            await _unitOfWork.Save();

        
            return Unit.Value;
        }
    }
}

using AutoMapper;
using Comp.ProductManagement.Application.Contracts.Persistence;
using Comp.ProductManagement.Application.DTOs.Product.Validator;
using Comp.ProductManagement.Application.Exceptions;
using Comp.ProductManagement.Application.Features.Product.Requests.Commands;
using Comp.ProductManagement.Application.Responses;
using Comp.ProductManagement.Domain;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Comp.ProductManagement.Application.Features.Product.Handlers.Commands
{
    public class CreateProductRequestHandler : IRequestHandler<CreateProductCommand, BaseCommandResponse>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CreateProductRequestHandler(
            IUnitOfWork unitOfWork,
            IMapper mapper)
        {
            this._unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<BaseCommandResponse> Handle(CreateProductCommand request, CancellationToken cancellationToken)
        {
            var response = new BaseCommandResponse();
            var validator = new CreateProductDtoValidator();
            var validationResult = await validator.ValidateAsync(request.ProductDto);

            if (validationResult.IsValid == false)
            {
                response.Success = false;
                response.Message = "Creation Failed";
                response.Errors = validationResult.Errors.Select(q => q.ErrorMessage).ToList();
            }
            else
            {
                var product = _mapper.Map<Domain.Product>(request.ProductDto);

                product = await _unitOfWork.ProductRepository.Add(product);
                await _unitOfWork.Save();

                response.Success = true;
                response.Message = "Creation Successful";
                response.Id = product.Id;
            }

        

            return response;
        }
    }
}

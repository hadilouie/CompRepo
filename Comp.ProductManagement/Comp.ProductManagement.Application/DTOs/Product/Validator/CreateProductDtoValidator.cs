using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Comp.ProductManagement.Application.DTOs.Product.Validator
{
    public class CreateProductDtoValidator : AbstractValidator<CreateProductDto>
    {
        public CreateProductDtoValidator()
        {
            Include(new IProductDtoValidator());
        }
    }
}

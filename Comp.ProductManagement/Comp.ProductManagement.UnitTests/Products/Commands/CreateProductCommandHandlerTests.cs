using AutoMapper;
using Comp.ProductManagement.Application.Contracts.Persistence;
using Comp.ProductManagement.Application.DTOs.Product;
using Comp.ProductManagement.Application.Exceptions;
using Comp.ProductManagement.Application.Features.Product.Handlers.Commands;
using Comp.ProductManagement.Application.Features.Product.Requests.Commands;
using Comp.ProductManagement.Application.Profiles;
using Comp.ProductManagement.Application.Responses;
using Comp.ProductManagement.UnitTests.Mocks;
using Moq;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace Comp.ProductManagement.UnitTests.Products.Commands
{
    public class CreateProductCommandHandlerTests
    {
        private readonly IMapper _mapper;

        private readonly Mock<IUnitOfWork> _mockUow;
        private readonly CreateProductDto _productDto;
        private readonly CreateProductRequestHandler _handler;

        public CreateProductCommandHandlerTests()
        {
            _mockUow = MockUnitOfWork.GetUnitOfWork();

            var mapperConfig = new MapperConfiguration(c =>
            {
                c.AddProfile<MappingProfile>();
            });

            _mapper = mapperConfig.CreateMapper();
     
            _handler = new CreateProductRequestHandler(_mockUow.Object, _mapper);

            _productDto = new CreateProductDto
            {
                ProductName = "Product X",
                Price = 40,
                ProductDescription = "Product X Description"
            };
        }

        [Fact]
        public async Task Valid_Product_Added()
        {
            var result = await _handler.Handle(new CreateProductCommand() { ProductDto = _productDto }, CancellationToken.None);

            var products = await _mockUow.Object.ProductRepository.GetAll();

            result.ShouldBeOfType<BaseCommandResponse>();

            products.Count.ShouldBe(4);
        }

        [Fact]
        public async Task InValid_Product_Added()
        {
            _productDto.Price = 0;

            var result = await _handler.Handle(new CreateProductCommand() { ProductDto = _productDto }, CancellationToken.None);

            var products = await _mockUow.Object.ProductRepository.GetAll();

            products.Count.ShouldBe(3);

            result.ShouldNotBeNull();

            result.ShouldBeOfType<BaseCommandResponse>();
        }
    }
}

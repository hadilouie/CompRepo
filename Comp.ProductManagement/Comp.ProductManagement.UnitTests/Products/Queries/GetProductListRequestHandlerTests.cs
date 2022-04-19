using AutoMapper;
using Comp.ProductManagement.Application.Contracts.Persistence;
using Comp.ProductManagement.Application.DTOs.Product;
using Comp.ProductManagement.Application.Features.Product.Handlers.Queries;
using Comp.ProductManagement.Application.Features.Product.Requests.Queries;
using Comp.ProductManagement.Application.Profiles;
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

namespace Comp.ProductManagement.UnitTests.Products.Queries
{
    public class GetProductListRequestHandlerTests
    {
        private readonly IMapper _mapper;
        private readonly Mock<IUnitOfWork> _mockUow;

        public GetProductListRequestHandlerTests()
        {
            _mockUow = MockUnitOfWork.GetUnitOfWork();

            var mapperConfig = new MapperConfiguration(c =>
            {
                c.AddProfile<MappingProfile>();
            });

            _mapper = mapperConfig.CreateMapper();
        }

        [Fact]
        public async Task GetProductListTest()
        {
            var handler = new GetProductListRequestHandler(_mockUow.Object, _mapper);

            var result = await handler.Handle(new GetProductListRequest(), CancellationToken.None);

            result.ShouldBeOfType<List<ProductDto>>();

            result.Count.ShouldBe(3);
        }
    }
}

using Comp.ProductManagement.Application.Contracts.Persistence;
using Comp.ProductManagement.Domain;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Comp.ProductManagement.UnitTests.Mocks
{
    public static class MockProductRepository
    {
        public static Mock<IProductRepository> GetProductTypeRepository()
        {
            var products = new List<Product>
            {
                new Product
                {
                    Id = 1,
                    ProductName= "Product A",
                    Price= 10,
                    ProductDescription = "Product A Description"
                },
                new Product
                {
                    Id = 2,
                    ProductName= "Product B",
                    Price= 10,
                    ProductDescription = "Product B Description"
                },
                new Product
                {
                    Id = 3,
                    ProductName= "Product C",
                    Price= 40,
                    ProductDescription = "Product C Description"
                }
            };

            var mockRepo = new Mock<IProductRepository>();

            mockRepo.Setup(r => r.GetAll()).ReturnsAsync(products);

            mockRepo.Setup(r => r.Add(It.IsAny<Product>())).ReturnsAsync((Product product) =>
            {
                products.Add(product);
                return product
                ;
            });

            return mockRepo;

        }
    }
}

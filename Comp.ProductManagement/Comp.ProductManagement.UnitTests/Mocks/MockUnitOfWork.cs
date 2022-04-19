using Comp.ProductManagement.Application.Contracts.Persistence;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Comp.ProductManagement.UnitTests.Mocks
{
    public static class MockUnitOfWork
    {
        public static Mock<IUnitOfWork> GetUnitOfWork()
        {
            var mockUuni = new Mock<IUnitOfWork>();
            var mockProductRepo = MockProductRepository.GetProductTypeRepository();

            mockUuni.Setup(r => r.ProductRepository).Returns(mockProductRepo.Object);

            return mockUuni;
        }
    }
}

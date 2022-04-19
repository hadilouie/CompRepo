using Comp.ProductManagement.Application.Contracts.Persistence;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Comp.ProductManagement.Persistence.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {

        private readonly ProductManagementDbContext _context;

        private IProductRepository _productRepository;


        public UnitOfWork(ProductManagementDbContext context)
        {
            _context = context;
        }

        public IProductRepository ProductRepository =>
            _productRepository ??= new ProductRepository(_context);


        public void Dispose()
        {
            _context.Dispose();
            GC.SuppressFinalize(this);
        }

        public async Task Save()
        {

            await _context.SaveChangesAsync();
        }
    }
}

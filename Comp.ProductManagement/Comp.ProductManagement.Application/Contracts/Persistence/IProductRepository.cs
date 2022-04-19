using Comp.ProductManagement.Domain;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Comp.ProductManagement.Application.Contracts.Persistence
{
    public interface IProductRepository : IGenericRepository<Product>
    {
    }
}

using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Comp.ProductManagement.Application.Contracts.Persistence
{
    public interface IUnitOfWork : IDisposable
    {
        IProductRepository ProductRepository { get; }
        Task Save();
    }
}

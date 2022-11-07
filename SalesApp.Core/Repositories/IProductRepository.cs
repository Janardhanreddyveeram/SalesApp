using SalesApp.Core.Entities;
using SalesApp.Core.Repositories.Base;

namespace SalesApp.Core.Repositories
{
    public interface IProductRepository: IRepository<Product>
    {
        Task<Product> UpdateAsync(Product product);
    }
}

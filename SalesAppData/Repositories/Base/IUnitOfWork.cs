using SalesApp.Core.Repositories;

namespace SalesAppData.Repositories.Base
{
    public interface IUnitOfWork
    {
        IProductRepository Product { get; }
    }
}

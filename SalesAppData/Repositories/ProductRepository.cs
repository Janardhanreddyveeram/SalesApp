using SalesApp.Core.Entities;
using SalesApp.Core.Repositories;
using SalesAppData.Data;
using SalesAppData.Repositories.Base;


namespace SalesAppData.Repositories
{
    public class ProductRepository : Repository<Product>, IProductRepository
    {
        private readonly SalesAppDbcontext _context;
        public ProductRepository(SalesAppDbcontext context) : base(context)
        {
            _context= context;
        }

        public async Task<Product> UpdateAsync(Product product)
        {
            _context.Set<Product>().Update(product);
            await _context.SaveChangesAsync();
            return product;
        }
    }
}

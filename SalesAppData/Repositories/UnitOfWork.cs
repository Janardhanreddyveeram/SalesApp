using SalesApp.Core.Repositories;
using SalesAppData.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesAppData.Repositories
{
    public class UnitOfWork 
    {
        public UnitOfWork(SalesAppDbcontext dbContext)
        {
            Product = new ProductRepository(dbContext);
            
            
        }       
        public IProductRepository Product { get; private set; }
    }
}

using SalesApp.Core.Repositories;
using SalesAppData.Data;
using SalesAppData.Repositories.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesAppData.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        public UnitOfWork(SalesAppDbcontext dbContext)
        {
            Product = new ProductRepository(dbContext);                        
        }       
        public IProductRepository Product { get; private set; }
    }
}

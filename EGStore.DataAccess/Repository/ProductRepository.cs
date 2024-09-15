using EGStore.DataAccess.Repository.IRepository;
using EGStore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EGStore.DataAccess.Repository
{
    internal class ProductRepository : Repository<Product> ,IProductRepository
    {
        public ProductRepository (ApplicationDbContext context): base(context) { }  
    }
}

using EGStore.DataAccess.Repository.IRepository;
using EGStore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EGStore.DataAccess.Repository
{
    public class BrandRepository : Repository<Brand> ,IBrandRepository
    {
        public BrandRepository(ApplicationDbContext context) : base(context) { }
    }
}

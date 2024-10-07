using EGStore.DataAccess.Repository.IRepository;
using EGStore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EGStore.DataAccess.Repository
{
    public class WishListRepository : Repository<WishList>, IWishListRepository
    {
        public WishListRepository(ApplicationDbContext context) : base(context)
        {
        }

        
    }
}

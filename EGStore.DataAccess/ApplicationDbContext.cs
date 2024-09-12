using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using EGStore.Models;

namespace EGStore.DataAccess
{
    public class ApplicationDbContext : IdentityDbContext<IdentityUser> 
    {
        public DbSet<ApplicationUser> ApplicationUsers {  get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> products { get; set; }
        public DbSet<Brand> brands { get; set; }
        public DbSet<Order> orders { get; set; }
        public DbSet<OrderDetails> orderDetails { get; set; }
        public DbSet<Cart> carts { get; set; }
        public DbSet<Review> reviews { get; set; }
        public DbSet<Shipping> shippings { get; set; }
        public DbSet<WishList> wishLists { get; set; }
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
        {

        }

    }
}

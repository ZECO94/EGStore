﻿using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using EGStore.Models;

namespace EGStore.DataAccess
{
    public class ApplicationDbContext : IdentityDbContext<IdentityUser> 
    {
        public DbSet<ApplicationUser> ApplicationUsers { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> products { get; set; }
        public DbSet<Brand> brands { get; set; }
        public DbSet<Order> orders { get; set; }
        public DbSet<OrderDetails> orderDetails { get; set; }
        public DbSet<Cart> carts { get; set; }
        public DbSet<Review> reviews { get; set; }
        public DbSet<WishList> wishLists { get; set; }
        

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
        {

        }

        public ApplicationDbContext()
        {
        }
        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    base.OnConfiguring(optionsBuilder);
        //    optionsBuilder.UseSqlServer("Data Source=.;Initial Catalog=DBEGStore;Integrated Security=True;TrustServerCertificate=True");
        //}

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

              
            builder.Entity<IdentityRole>().HasData(
                new IdentityRole { Name = "Admin", NormalizedName = "ADMIN" },
                new IdentityRole { Name = "Manager", NormalizedName = "MANAGER" },
                new IdentityRole { Name = "User", NormalizedName = "USER" }
            );
        }
        //protected override void OnModelCreating(ModelBuilder builder)
        //{
        //    base.OnModelCreating(builder);
        //    // Customize the ASP.NET Identity model and override the defaults if needed.
        //    // For example, you can rename the ASP.NET Identity table names and more.
        //    // Add your customizations after calling base.OnModelCreating(builder);
        //}

    }
}

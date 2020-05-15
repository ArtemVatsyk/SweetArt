using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;


namespace SweetArt.Models
{
    public class CakeContext : DbContext
    {
        public CakeContext(DbContextOptions options) : base("DefaultConnection") { }

        public DbSet<Product> Products;
        public DbSet<Order> Orders;
        public DbSet<Customer> Customers;
        public DbSet<OrderItem> OrderItems;
        public DbSet<Category> Categories;
    }
}

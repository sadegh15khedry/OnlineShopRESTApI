using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using test.Models;

namespace test.Data
{
    public class ShopDbContext : DbContext
    {
        public DbSet<Item> Items { set; get; }
        public DbSet<User> Users { set; get; }
        public ShopDbContext(DbContextOptions<ShopDbContext> options) : base(options)
        {

        }
    }
}

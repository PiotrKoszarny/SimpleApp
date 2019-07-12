using Microsoft.EntityFrameworkCore;
using SimpleApp.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SimpleApp.DAL
{
    public class SimpleAppDbContext : DbContext
    {
        public SimpleAppDbContext(DbContextOptions<SimpleAppDbContext> options) : base(options)
        {

        }

        public DbSet<ProductEntity> Products { get; set; }
    }
}

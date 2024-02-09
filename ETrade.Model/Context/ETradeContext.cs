using ETrade.Model.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETrade.Model.Context
{
    public class ETradeContext : DbContext
    {
        public ETradeContext(DbContextOptions<ETradeContext> dbContextOptions) : base(dbContextOptions) 
        {
        }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
        
    } 
}

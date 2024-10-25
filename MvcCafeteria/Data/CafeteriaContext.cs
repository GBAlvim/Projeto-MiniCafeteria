using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MvcCafeteria.Models;

namespace MvcCafeteria.Data
{
    public class CafeteriaContext : DbContext
    {
        public CafeteriaContext (DbContextOptions<CafeteriaContext> options)
            : base(options)
        {
        }

        public DbSet<MvcCafeteria.Models.Product> Product { get; set; } = default!;
        public DbSet<MvcCafeteria.Models.Order> Order { get; set; } = default!;
        
    }
}

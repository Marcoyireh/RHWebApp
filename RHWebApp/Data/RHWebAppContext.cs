using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using RHWebApp.Models;

namespace RHWebApp.Data
{
    public class RHWebAppContext : DbContext
    {
        public RHWebAppContext (DbContextOptions<RHWebAppContext> options)
            : base(options)
        {
        }

        public DbSet<RHWebApp.Models.Employees> Employees { get; set; } = default!;
    }
}

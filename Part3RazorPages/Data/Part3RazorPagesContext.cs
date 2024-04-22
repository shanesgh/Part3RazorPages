using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Part3RazorPages.Models;

namespace Part3RazorPages.Data
{
    public class Part3RazorPagesContext : DbContext
    {
        public Part3RazorPagesContext (DbContextOptions<Part3RazorPagesContext> options)
            : base(options)
        {
        }

        public DbSet<Part3RazorPages.Models.Product> Product { get; set; } = default!;
    }
}

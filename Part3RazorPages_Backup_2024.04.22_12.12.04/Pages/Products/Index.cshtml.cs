using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Part3RazorPages.Data;
using Part3RazorPages.Models;

namespace Part3RazorPages.Pages.Products
{
    public class IndexModel : PageModel
    {
        private readonly Part3RazorPages.Data.Part3RazorPagesContext _context;

        public IndexModel(Part3RazorPages.Data.Part3RazorPagesContext context)
        {
            _context = context;
        }

        public IList<Product> Product { get;set; } = default!;

        [BindProperty(SupportsGet = true)]
        public string? SearchString { get; set; }

        public async Task OnGetAsync()
        {
            var products = from m in _context.Product
                         select m;
            if (!string.IsNullOrEmpty(SearchString))
            {
                products = products.Where(s => s.Name.Contains(SearchString));
            }

            Product = await products.ToListAsync();
        }
    }
}

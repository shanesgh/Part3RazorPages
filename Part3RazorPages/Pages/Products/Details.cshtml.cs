using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Part3RazorPages.Data;
using Part3RazorPages.Models;

namespace Part3RazorPages.Pages.Products
{
    public class DetailsModel : PageModel
    {
        private readonly Part3RazorPages.Data.Part3RazorPagesContext _context;

        public DetailsModel(Part3RazorPages.Data.Part3RazorPagesContext context)
        {
            _context = context;
        }

        public Product Product { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var product = await _context.Product.FirstOrDefaultAsync(m => m.Id == id);
            if (product == null)
            {
                return NotFound();
            }
            else
            {
                Product = product;
            }
            return Page();
        }
    }
}

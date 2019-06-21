using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using DotNetCoreApp.Core;
using DotNetCoreApp.Data;

namespace DotNetCoreApp.Pages.R2
{
    public class CreateModel : PageModel
    {
        private readonly DotNetCoreApp.Data.DotNetCoreAppDbContext _context;

        public CreateModel(DotNetCoreApp.Data.DotNetCoreAppDbContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Restaurant Restaurant { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Restaurants.Add(Restaurant);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
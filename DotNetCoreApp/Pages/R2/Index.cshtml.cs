using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using DotNetCoreApp.Core;
using DotNetCoreApp.Data;

namespace DotNetCoreApp.Pages.R2
{
    public class IndexModel : PageModel
    {
        private readonly DotNetCoreApp.Data.DotNetCoreAppDbContext _context;

        public IndexModel(DotNetCoreApp.Data.DotNetCoreAppDbContext context)
        {
            _context = context;
        }

        public IList<Restaurant> Restaurant { get;set; }

        public async Task OnGetAsync()
        {
            Restaurant = await _context.Restaurants.ToListAsync();
        }
    }
}

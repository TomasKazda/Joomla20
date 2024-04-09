using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Joomla20.Data;
using Joomla20.Models;

namespace Joomla20.Pages.Management
{
    public class IndexModel : PageModel
    {
        private readonly Joomla20.Data.ApplicationDbContext _context;

        public IndexModel(Joomla20.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<Article> Article { get;set; } = default!;

        public async Task OnGetAsync()
        {
            Article = await _context.Articles
                .Include(a => a.Author).ToListAsync();
        }
    }
}

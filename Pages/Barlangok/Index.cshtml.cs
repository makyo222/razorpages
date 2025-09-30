using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using WebApplication2.Data;
using WebApplication2.Models;
using WebApplication2.Data;
using WebApplication2.Models;

namespace WebApplication2.Pages.Barlangok
{
    public class IndexModel : PageModel
    {
        private readonly BarlangDbContext _context;

        public IndexModel(BarlangDbContext context)
        {
            _context = context;
        }

        public IList<barlang> BarlangList { get; set; } = default!;

        [BindProperty(SupportsGet = true)]
        public string? SearchTelepules { get; set; }

        public async Task OnGetAsync()
        {
            var query = _context.Barlangok.AsQueryable();

            if (!string.IsNullOrEmpty(SearchTelepules))
            {
                query = query.Where(b => b.telepules.Contains(SearchTelepules));
            }

            BarlangList = await query.ToListAsync();
        }
    }
}


using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using WebApplication2.Data;
using WebApplication2.Models;

namespace WebApplication2.Pages
{
    public class OsszesitoModel : PageModel
    {
        private readonly BarlangDbContext _context;

        public OsszesitoModel(BarlangDbContext context)
        {
            _context = context;
        }

        public List<TelepulesOsszesito> Osszesites { get; set; } = new List<TelepulesOsszesito>();

        public async Task OnGetAsync()
        {
            Osszesites = await _context.Barlangok
                .GroupBy(b => b.telepules)
                .Select(g => new TelepulesOsszesito
                {
                    Telepules = g.Key,
                    BarlangSzam = g.Count()
                })
                .ToListAsync();
        }

        public class TelepulesOsszesito
        {
            public string Telepules { get; set; } = string.Empty;
            public int BarlangSzam { get; set; }
        }
    }
}

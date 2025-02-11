using CarStore.Web.Data;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace CarStore.Razor.Pages
{
    public class CarsModel : PageModel
    {
        [Inject]
        public ApplicationDbContext Context { get; set; }

        [BindProperty]
        public List<string?> CarNames { get; set; } // View model

        [BindProperty]
        public string FilterString { get; set; } = "";

        public async Task OnGetAsync()
        {
            CarNames = await Context.Cars.Select(c => c.ToString()).ToListAsync();
        }

        public async Task OnPostAsync()
        {
            CarNames = await Context.Cars
                .Where(c => c.ToString().Contains(FilterString))
                .Select(c => c.ToString())
                .ToListAsync();
        }
    }
}

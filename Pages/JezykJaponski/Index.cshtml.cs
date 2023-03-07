using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SlownikObcy2.Data;
using SlownikObcy2.Models;

namespace SlownikObcy2.Pages.TlumaJaponski
{
    public class IndexModel : PageModel
    {
        private readonly SlownikObcy2.Data.SlownikObcy2Context _context;

        public IndexModel(SlownikObcy2.Data.SlownikObcy2Context context)
        {
            _context = context;
        }

        public PaginatedList<Japonski> Japonski { get; set; }
        public string RomajiSort { get; set; }
        public string PolskiSort { get; set; }
        public string CurrentSort { get; set; }
        public string CurrentFilter { get; set; }

        public async Task OnGetAsync(string SzukanaFraza, string SortOrder, string currentFilter, int? pageIndex)
        {
            CurrentSort = SortOrder;
            RomajiSort = String.IsNullOrEmpty(SortOrder) ? "Romaji_desc" : "";
            PolskiSort = SortOrder == "Polski" ? "Polski_desc" : "Polski";

            if (SzukanaFraza != null)
            {
                pageIndex = 1;
            }
            else
            {
                SzukanaFraza = currentFilter;
            }

            CurrentFilter = SzukanaFraza;

            IQueryable<Japonski> hasla = from m in _context.Japonski select m;

            switch (SortOrder)
            {
                case "Romaji_desc":
                    hasla = hasla.OrderByDescending(s => s.Romaji);
                    break;
                case "Polski":
                    hasla = hasla.OrderBy(s => s.Polski);
                    break;
                case "Polski_desc":
                    hasla = hasla.OrderByDescending(s => s.Polski);
                    break;
                default:
                    hasla = hasla.OrderBy(s => s.Romaji);
                    break;
            }

            if (!string.IsNullOrEmpty(SzukanaFraza))
            {
                hasla = hasla.Where(s => s.Romaji.Substring(0, SzukanaFraza.Length).Contains(SzukanaFraza) || s.Polski.Substring(0, SzukanaFraza.Length).Contains(SzukanaFraza));
            }

            int pageSize = 5;

            Japonski = await PaginatedList<Japonski>.CreateAsync(
                hasla.AsNoTracking(), pageIndex ?? 1, pageSize);
        }


        [BindProperty(SupportsGet = true)]
        public string SzukanaFraza { get; set; }

        [TempData]
        public string Message { get; set; }

        public async Task<IActionResult> OnPostDelete(int Id)
        {
            var haslo = await _context.Japonski.FindAsync(Id);
            if (haslo == null)
            {
                return NotFound();
            }
            _context.Japonski.Remove(haslo);

            await _context.SaveChangesAsync();

            Message = "Usunięto hasło słownikowe: " + haslo.Romaji + " - " + haslo.Polski;

            return RedirectToPage("Index");
        }
    }
}
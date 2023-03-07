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

namespace SlownikObcy2.Pages.TlumaAngielski
{
    public class IndexModel : PageModel
    {
        private readonly SlownikObcy2.Data.SlownikObcy2Context _context;

        public IndexModel(SlownikObcy2.Data.SlownikObcy2Context context)
        {
            _context = context;
        }

        public PaginatedList<Angielski> Angielski { get; set; }
        public string ObcySort { get; set; }
        public string PolskiSort { get; set; }
        public string CurrentSort { get; set; }
        public string CurrentFilter { get; set; }

        public async Task OnGetAsync(string SzukanaFraza, string SortOrder, string currentFilter, int? pageIndex)
        {
            CurrentSort = SortOrder;
            ObcySort = String.IsNullOrEmpty(SortOrder) ? "Obcy_desc" : "";
            PolskiSort = SortOrder ==  "Polski" ? "Polski_desc" : "Polski";

            if(SzukanaFraza != null)
            {
                pageIndex = 1;
            }
            else
            {
                SzukanaFraza = currentFilter;
            }

            CurrentFilter = SzukanaFraza;

            IQueryable<Angielski> hasla = from m in _context.Angielski select m;

            switch (SortOrder)
            {
                case "Obcy_desc":
                    hasla = hasla.OrderByDescending(s => s.Obcy);
                    break;
                case "Polski":
                    hasla = hasla.OrderBy(s => s.Polski);
                    break;
                case "Polski_desc":
                    hasla = hasla.OrderByDescending(s => s.Polski);
                    break;
                default:
                    hasla = hasla.OrderBy(s => s.Obcy);
                    break;
            }

            if (!string.IsNullOrEmpty(SzukanaFraza))
            {
                hasla = hasla.Where(s => s.Obcy.Substring(0, SzukanaFraza.Length).Contains(SzukanaFraza) || s.Polski.Substring(0, SzukanaFraza.Length).Contains(SzukanaFraza));
            }

            int pageSize = 5;

            Angielski = await PaginatedList<Angielski>.CreateAsync(
                hasla.AsNoTracking(), pageIndex ?? 1, pageSize);
        }


        [BindProperty(SupportsGet = true)]
        public string SzukanaFraza { get; set; }

        [TempData]
        public string Message { get; set; }

        public async Task<IActionResult> OnPostDelete(int Id)
        {
            var haslo = await _context.Angielski.FindAsync(Id);
            if (haslo == null)
            {
                return NotFound();
            }
            _context.Angielski.Remove(haslo);

            await _context.SaveChangesAsync();

            Message = "Usunięto hasło słownikowe: " + haslo.Obcy + " - " + haslo.Polski;

            return RedirectToPage("Index");
        }
    }
}

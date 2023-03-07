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
    public class EditModel : PageModel
    {
        private readonly SlownikObcy2.Data.SlownikObcy2Context _context;

        public EditModel(SlownikObcy2.Data.SlownikObcy2Context context)
        {
            _context = context;
        }

        [BindProperty]
        public Japonski Japonski { get; set; }
        [TempData]
        public string Message { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Japonski = await _context.Japonski.FirstOrDefaultAsync(m => m.ID == id);

            if (Japonski == null)
            {
                return NotFound();
            }
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Japonski).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!JaponskiExists(Japonski.ID))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
            Message = "Edytowano hasło słownikowe.";
            return RedirectToPage("./Index");
        }

        private bool JaponskiExists(int id)
        {
            return _context.Japonski.Any(e => e.ID == id);
        }
    }
}

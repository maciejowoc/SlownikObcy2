using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using SlownikObcy2.Data;
using SlownikObcy2.Models;

namespace SlownikObcy2.Pages.TlumaJaponski
{
    public class CreateModel : PageModel
    {
        private readonly SlownikObcy2.Data.SlownikObcy2Context _context;

        public CreateModel(SlownikObcy2.Data.SlownikObcy2Context context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Japonski Japonski { get; set; }
        [TempData]
        public string Message { get; set; }

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Japonski.Add(Japonski);
            await _context.SaveChangesAsync();
            Message = "Dodano hasło: " + Japonski.Romaji + " - " + Japonski.Polski;
            return RedirectToPage("./Index");
        }
    }
}

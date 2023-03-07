using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using SlownikObcy2.Data;
using SlownikObcy2.Models;

namespace SlownikObcy2.Pages.TlumaAngielski
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
        public Angielski Angielski { get; set; }

        [TempData]
        public string Message { get; set; }

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Angielski.Add(Angielski);
            await _context.SaveChangesAsync();

            Message = "Dodano hasło: " + Angielski.Obcy + " - " + Angielski.Polski;

            return RedirectToPage("./Index");
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using SlownikObcy2.Data;
using SlownikObcy2.Models;

namespace SlownikObcy2.Pages.TlumaJaponski
{
    public class DetailsModel : PageModel
    {
        private readonly SlownikObcy2.Data.SlownikObcy2Context _context;

        public DetailsModel(SlownikObcy2.Data.SlownikObcy2Context context)
        {
            _context = context;
        }

        public Japonski Japonski { get; set; }

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
    }
}

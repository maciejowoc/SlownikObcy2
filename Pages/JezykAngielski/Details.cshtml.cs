using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using SlownikObcy2.Data;
using SlownikObcy2.Models;

namespace SlownikObcy2.Pages.TlumaAngielski
{
    public class DetailsModel : PageModel
    {
        private readonly SlownikObcy2.Data.SlownikObcy2Context _context;

        public DetailsModel(SlownikObcy2.Data.SlownikObcy2Context context)
        {
            _context = context;
        }

        public Angielski Angielski { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Angielski = await _context.Angielski.FirstOrDefaultAsync(m => m.ID == id);

            if (Angielski == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}

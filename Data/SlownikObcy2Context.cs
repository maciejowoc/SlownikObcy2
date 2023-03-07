using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SlownikObcy2.Models;

namespace SlownikObcy2.Data
{
    public class SlownikObcy2Context : DbContext
    {
        public SlownikObcy2Context (DbContextOptions<SlownikObcy2Context> options)
            : base(options)
        {
        }

        public DbSet<SlownikObcy2.Models.Angielski> Angielski { get; set; }
        public DbSet<SlownikObcy2.Models.Japonski> Japonski { get; set; }
    }
}

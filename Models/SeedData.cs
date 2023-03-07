using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SlownikObcy2.Data;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;

namespace SlownikObcy2.Models
{
    public class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new SlownikObcy2Context(
                serviceProvider.GetRequiredService<
                DbContextOptions<SlownikObcy2Context>>()))
            {
                if (context.Angielski.Any())
                {
                    return;
                }

                context.Angielski.AddRange(
                    new Angielski
                    {
                        Obcy = "Bird",
                        Polski = "Ptak"
                    },
                    new Angielski
                    {
                        Obcy = "Clock",
                        Polski = "Zegar"
                    }
                   );
                context.SaveChanges();
            }
        }
    }
}

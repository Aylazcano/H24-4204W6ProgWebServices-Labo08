using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using H24_4204W6ProgWebServices_Labo08.Models;

namespace H24_4204W6ProgWebServices_Labo08.Data
{
    public class H24_4204W6ProgWebServices_Labo08Context : DbContext
    {
        public H24_4204W6ProgWebServices_Labo08Context (DbContextOptions<H24_4204W6ProgWebServices_Labo08Context> options)
            : base(options)
        {
        }

        public DbSet<H24_4204W6ProgWebServices_Labo08.Models.Animal> Animal { get; set; } = default!;
    }
}

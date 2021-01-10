using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Serb_Diana_Proiect.Models;

namespace Serb_Diana_Proiect.Data
{
    public class Serb_Diana_ProiectContext : DbContext
    {
        public Serb_Diana_ProiectContext (DbContextOptions<Serb_Diana_ProiectContext> options)
            : base(options)
        {
        }

        public DbSet<Serb_Diana_Proiect.Models.Car> Car { get; set; }

        public DbSet<Serb_Diana_Proiect.Models.Motor> Motor { get; set; }

        public DbSet<Serb_Diana_Proiect.Models.Categorie> Categorie { get; set; }
    }
}

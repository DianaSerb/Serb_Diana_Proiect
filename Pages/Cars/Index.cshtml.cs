using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Serb_Diana_Proiect.Data;
using Serb_Diana_Proiect.Models;

namespace Serb_Diana_Proiect.Pages.Cars
{
    public class IndexModel : PageModel
    {
        private readonly Serb_Diana_Proiect.Data.Serb_Diana_ProiectContext _context;

        public IndexModel(Serb_Diana_Proiect.Data.Serb_Diana_ProiectContext context)
        {
            _context = context;
        }

        public IList<Car> Car { get;set; }
        public CarData CarD { get; set; }
        public int CarID { get; set; }
        public int CategorieID { get; set; }

        public async Task OnGetAsync(int? id, int? categorieID)
        {
            CarD = new CarData();

            CarD.Cars = await _context.Car
                .Include(b=>b.Motor)
                .Include(b=>b.CategoriiMasina)
                .ThenInclude(b=>b.Categorie)
                .AsNoTracking()
                .OrderBy(b=>b.Marca)
                .ToListAsync();

            if (id != null) 
            { 
                CarID = id.Value;
                Car car = CarD.Cars
                    .Where(i => i.ID == id.Value).Single();
                CarD.Categorii = car.CategoriiMasina.Select(s => s.Categorie);
            }
        }
    }
}

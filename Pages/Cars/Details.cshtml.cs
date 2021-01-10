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
    public class DetailsModel : PageModel
    {
        private readonly Serb_Diana_Proiect.Data.Serb_Diana_ProiectContext _context;

        public DetailsModel(Serb_Diana_Proiect.Data.Serb_Diana_ProiectContext context)
        {
            _context = context;
        }

        public Car Car { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Car = await _context.Car.FirstOrDefaultAsync(m => m.ID == id);

            if (Car == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}

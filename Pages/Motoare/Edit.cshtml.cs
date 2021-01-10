using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Serb_Diana_Proiect.Data;
using Serb_Diana_Proiect.Models;

namespace Serb_Diana_Proiect.Pages.Motoare
{
    public class EditModel : PageModel
    {
        private readonly Serb_Diana_Proiect.Data.Serb_Diana_ProiectContext _context;

        public EditModel(Serb_Diana_Proiect.Data.Serb_Diana_ProiectContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Motor Motor { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Motor = await _context.Motor.FirstOrDefaultAsync(m => m.ID == id);

            if (Motor == null)
            {
                return NotFound();
            }
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Motor).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MotorExists(Motor.ID))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool MotorExists(int id)
        {
            return _context.Motor.Any(e => e.ID == id);
        }
    }
}

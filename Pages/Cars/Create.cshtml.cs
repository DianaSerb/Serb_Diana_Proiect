using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Serb_Diana_Proiect.Data;
using Serb_Diana_Proiect.Models;

namespace Serb_Diana_Proiect.Pages.Cars
{
    public class CreateModel : CarCategoriesPageModel
    {
        private readonly Serb_Diana_Proiect.Data.Serb_Diana_ProiectContext _context;

        public CreateModel(Serb_Diana_Proiect.Data.Serb_Diana_ProiectContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            ViewData["MotorID"] = new SelectList(_context.Set<Motor>(), "ID", "TipMotor");
            var car = new Car();
            car.CategoriiMasina = new List<CategorieMasina>();
            PopulateAssignedCategoryData(_context, car);
            return Page();
        }

        [BindProperty]
        public Car Car { get; set; }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync(string[] selectedCategories)
        {
            /*if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Car.Add(Car);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");*/

            var newCar = new Car();
            if (selectedCategories != null)
            {
                newCar.CategoriiMasina = new List<CategorieMasina>();
                foreach (var cat in selectedCategories)
                {
                    var catToAdd = new CategorieMasina
                    {
                        CategorieID = int.Parse(cat)
                    }; 
                    newCar.CategoriiMasina.Add(catToAdd);
                }
            }
            if (await TryUpdateModelAsync<Car>(
                newCar,
                "Car",
                i => i.Marca, i => i.Model,
                i => i.Pret, i => i.Motor, i=>i.MotorID))
            { 
                _context.Car.Add(newCar);
                await _context.SaveChangesAsync(); 
                return RedirectToPage("./Index"); 
            }
            PopulateAssignedCategoryData(_context, newCar);
            return Page();
        }
    }
}

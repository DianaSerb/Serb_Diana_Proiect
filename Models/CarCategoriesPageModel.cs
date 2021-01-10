using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Serb_Diana_Proiect.Data;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Serb_Diana_Proiect.Models
{
    public class CarCategoriesPageModel : PageModel
    {
        public List<AssignedCategoryData> AssignedCategoryDataList;
        public void PopulateAssignedCategoryData(Serb_Diana_ProiectContext context, Car car)
        {
            var allCategories = context.Categorie;
            var carCategories = new HashSet<int>(
                car.CategoriiMasina.Select(c => c.CarID));
            AssignedCategoryDataList = new List<AssignedCategoryData>();
            foreach (var cat in allCategories)
            {
                AssignedCategoryDataList.Add(new AssignedCategoryData
                {
                    CategoryID = cat.ID,
                    Name = cat.NumeCategorie,
                    Assigned = carCategories.Contains(cat.ID)
                });
            }
        }
        public void UpdateCarCategories(Serb_Diana_ProiectContext context, string[] selectedCategories, Car carToUpdate)
        {
            if (selectedCategories == null)
            {
                carToUpdate.CategoriiMasina = new List<CategorieMasina>();
                return;
            }
            var selectedCategoriesHS = new HashSet<string>(selectedCategories);
            var carCategories = new HashSet<int>(
                carToUpdate.CategoriiMasina.Select(c => c.Categorie.ID));
            foreach (var cat in context.Categorie)
            {
                if (selectedCategoriesHS.Contains(cat.ID.ToString()))
                {
                    if (!carCategories.Contains(cat.ID))
                    {
                        carToUpdate.CategoriiMasina.Add(
                            new CategorieMasina
                            {
                                CarID = carToUpdate.ID,
                                CategorieID = cat.ID
                            });
                    }
                }
                else
                {
                    if (carCategories.Contains(cat.ID))
                    {
                        CategorieMasina courseToRemove
                            = carToUpdate
                            .CategoriiMasina
                            .SingleOrDefault(i => i.CategorieID == cat.ID);
                        context.Remove(courseToRemove);
                    }
                }
            }
        }
    }
}

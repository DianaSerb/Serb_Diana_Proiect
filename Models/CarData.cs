using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Serb_Diana_Proiect.Models
{
    public class CarData
    {
        public IEnumerable<Car> Cars { get; set; }
        public IEnumerable<Categorie> Categorii { get; set; }
        public IEnumerable<CategorieMasina> CategoriiMasina { get; set; }
    }
}

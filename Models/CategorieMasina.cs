using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Serb_Diana_Proiect.Models
{
    public class CategorieMasina
    {
        public int ID { get; set; }
        public int CarID { get; set; }
        public Car Car { get; set; }
        public int CategorieID { get; set; }
        public Categorie Categorie { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Serb_Diana_Proiect.Models
{
    public class Categorie
    {
        public int ID { get; set; }
        [Display(Name = "Categorie")]
        [Required]
        public string NumeCategorie { get; set; }
        
        public ICollection<CategorieMasina> CategoriiMasina { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Serb_Diana_Proiect.Models
{
    public class Car
    {
        public int ID { get; set; }
        [Required, StringLength(20, MinimumLength = 3)]
        public string Marca{ get; set;}
        [Required, StringLength(30)]
        public string Model { get; set; }
        [Range(1000,100000)]
        public int Pret { get; set; }

        
        public int MotorID { get; set; }
        
        public Motor Motor { get; set; }
        [Display(Name = "Categorie")]
        public ICollection<CategorieMasina> CategoriiMasina { get; set; }
    }
}

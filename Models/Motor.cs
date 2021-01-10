using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Serb_Diana_Proiect.Models
{
    public class Motor
    {
        public int ID { get; set; }
        [Display(Name = "Motorizare")]
        [Required]
        public string TipMotor { get; set; }
        public ICollection<Car> Cars {get;set;}
    }
}

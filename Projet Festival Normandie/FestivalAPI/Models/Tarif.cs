using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FestivalAPI.Models
{
    public class Tarif
    {
        [Key]
        public int TarifID { get; set; }
        [Required]
        public string NomTarif { get; set; } // Plein Tarif ou Demi Tarif
        public int PrixTarif { get; set; }
        public int QuantiteTotal { get; set;  }
        public string DescriptionTarif { get; set; }
        // Un Tarif peut être attribué à un festival ou non. 
        //La propriété FestivalID est incluse en tant que clé étrangère à l'entité Festival. Un point d'interrogation pour marquer la propriété comme nullable.
        public int? FestivalID { get; set; }
        public Festival Festival { get; set; }

    }
}

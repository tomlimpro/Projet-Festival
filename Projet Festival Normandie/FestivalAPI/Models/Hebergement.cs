using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FestivalAPI.Models
{
    // Dans un festival, on peut choisir un type d'herbegement. Pour cela, il existe plusieurs formules selon le budget du festivalier.
    // Exemple : 
    // Formule 1 : Tente Area, le festivalier peut s'installer librement avec son équipement(tente, sac de couchage) 
    // Formule 2 : Tente Area Package, ce pack contient une tente + matelas + sac de couchage
    // Formule 3 : Cabinet Area, Petite cabane qui dispose de 2 lits, chaise et table, serviette, lampe, parking
   
    public class Hebergement
    {
        [Key]
        public int HebergementID { get; set; }
        public string TypeHebergement { get; set; } // Hotel ou Woodcamp
        public string LienHebergement { get; set; }
        // Hebergement a une propriété de clé étrangère FestivalID qui pointe sur l'entité Festival associé 
        // et elle a une propriété de navigation Festival.
        public int FestivalID { get; set; }
        public Festival Festival { get; set; }
    }
}

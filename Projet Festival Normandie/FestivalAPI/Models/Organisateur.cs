using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
/// <summary>
/// Class Organisateur
/// La clé primaire est IdOrganisateur
/// Un organisateur est affecté à un festival.
/// </summary>
namespace FestivalAPI.Models
{
    public class Organisateur
    {
        [Key]
        public int OrganisateurID { get; set; }
        [Required]
        public string Nom { get; set; }
        public string Prenom { get; set; }
        public string Mot_de_passe { get; set; }
        public string Email { get; set; }

        // Organisateur a une propriété de clé étrangère FestivalID qui pointe sur l'entité Festival associé 
        // et elle a une propriété de navigation Festival.

        public int? FestivalID { get; set; }
        public Festival Festival { get; set; }
        
        
        
        

    }
}

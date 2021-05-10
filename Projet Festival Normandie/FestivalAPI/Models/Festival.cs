using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

/// <summary>
/// Class Festival 
/// Clé primaire est FestivalId
/// On remarquera qu'un festival possède des organisateurs.
/// </summary>
namespace FestivalAPI.Models
{
    public class Festival
    {

        [Key]
        public int FestivalID { get; set; }
        [Required]
        public string Nom_Festival { get; set; }
        public string Ville { get; set; }

        public string Description { get; set; }
        public string Logo { get; set; }
        public int QuantitePlace { get; set; }
        public bool Publier { get; set; }
        public DateTime DateDebut { get; set; }
        public DateTime DateFin { get; set; }

        // Un festival peut avoir plusieurs : 
        // - Tarifs
        // - Scenes
        // - Hebergements
        // - Organisateurs
        public ICollection<Artiste> Artiste { get; set; }
        public ICollection<Tarif> Tarif { get; set; }
        public ICollection<Scene> Scene { get; set; }
        public ICollection<Hebergement> Hebergement { get; set; }
        public ICollection<Organisateur> Organisateur { get; set; }

        public ICollection<FestivalierAssignment> FestivalierAssignments { get; set; }

        /*
        public Tarif Tarif { get; set; }
        public Scene Scene { get; set; }
        public Hebergement Hebergement { get; set; }
        public Organisateur Organisateur { get; set; }
        */





    }
}

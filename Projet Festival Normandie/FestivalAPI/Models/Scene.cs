using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FestivalAPI.Models
{
    public class Scene
    {
        [Key]
        public int SceneID { get; set; }
        [Required]
        public string Nom_Scene { get; set; }
        public int Capacite { get; set; }
        
        public string Accessibilite { get; set; }
        // Scene a une propriété de clé étrangère FestivalID qui pointe sur l'entité Festival associé 
        // et elle a une propriété de navigation Festival.
        public int FestivalID { get; set; }
        public Festival Festival { get; set; }
        // Une scene peut avoir une liste d'artiste.
        public ICollection<Artiste> Artistes { get; set; }
        

    }
}

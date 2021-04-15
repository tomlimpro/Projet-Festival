using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace FestivalAPI.Models
{
    public class Organisateur
    {
        [Key]
        public int IdOrganisateur { get; set; }
        [Required]
        public string Nom { get; set; }
        public string Prenom { get; set; }
        public string Mot_de_passe { get; set; }
        public string Email { get; set; }

        [ForeignKey("FK_Festival")]
        public int FestivalId{ get; set; }
        
        
        
        

    }
}

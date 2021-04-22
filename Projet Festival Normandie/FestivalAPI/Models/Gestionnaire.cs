using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FestivalAPI.Models
{
    public class Gestionnaire
    {
        [Key]
        public int IdGestionnaire { get; set; }
        [Required]
        public string Nom { get; set; }
        public string Prenom { get; set; }
        public string Mdp { get; set; }
        public string Email { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace FestivalAPI.Models
{
    public class Festival
    {

        [Key]
        public int FestivalId { get; set; }
        [Required]
        public string Nom_Festival { get; set; }
        public string Lieu { get; set; }

        public string Description { get; set; }
        public string Logo { get; set; }
       
        public virtual ICollection<Organisateur> Organisateurs { get; set; }





    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FestivalAPI.Models
{
    public class Artiste
    {
        [Key]
        public int ArtisteId { get; set; }
        [Required]
        public string Nom_Artiste { get; set; }
        public string Style_Artiste { get; set; }
        public string Descriptif_Artiste { get; set; }
        public string Pays_Artiste { get; set; }
        public string ExtraitMusical_Artiste { get; set; }

    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FestivalAPI.Models
{
    public class Artiste
    {
        [Key]
        public int ArtisteID { get; set; }
        [Required]
        [DisplayName("Artiste")]
        public string Nom_Artiste { get; set; }
        [DisplayName("Style musical")]
        public string Style_Artiste { get; set; }
        [DisplayName("Descriptif")]
        public string Descriptif_Artiste { get; set; }
        [DisplayName("Pays")]
        public string Pays_Artiste { get; set; }
        [DisplayName("Extrait musical")]
        public string ExtraitMusical_Artiste { get; set; }
        public int? FestivalID { get; set; }
        public Festival Festival { get; set; }
        public int? SceneID { get; set; }
        public Scene Scene { get; set; }
        public string UrlImage { get; set; }

    }
}

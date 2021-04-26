using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FestivalAPI.Models
{
    public class Festivalier
    {
        [Key]
        public int IdUser { get; set; }
        [Required]
        public string Nom { get; set; }
        [Required]
        public string Prenom { get; set; }

        [Required, MinLength(8)]
        [Display(Name = "Mot de passe" )]
        public string Mot_de_passe { get; set; }

        [Required]
        [RegularExpression(@"\A(?:[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?)\Z", ErrorMessage = "This is not an email")]
        public string Email { get; set; }

        public string Genre { get; set; }

        [MinLength(10),MaxLength(10)]
        public  string Telephone { get; set; }

        [Display(Name = "Code postal")]
        public int Code_postal { get; set; }
        public string Commune { get; set; }
        public string Pays { get; set; }

        [Required]
        [MinimumAge(18)]
        [Display(Name = "Date de naissance")]
        public DateTime Date_de_naissance { get; set; }

        public bool EmailConfirme { get; set; }


    }
}

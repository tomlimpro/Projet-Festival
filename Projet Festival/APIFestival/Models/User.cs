using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace APIFestival.Models
{
    public class User
    {
        public User() { }
        public User(int IdUser, string Nom, string Prenom, string Mot_de_passe, string Email)
        {
            this.IdUser = IdUser;
            this.Nom = Nom;
            this.Prenom     = Prenom;
            this.Mot_de_passe = Mot_de_passe;
            this.Email = Email;
        }

        [Key]
        public int IdUser { get; set; }
        [Required]
        public string Nom { get; set; }
        [Required]
        public string Prenom { get; set; }
        [Required]
        public string Mot_de_passe {get; set;}
        [Required]
        public string Email { get; set; }
       
        
    }
}

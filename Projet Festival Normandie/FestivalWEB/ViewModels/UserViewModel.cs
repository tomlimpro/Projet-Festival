using FestivalAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace FestivalWEB.ViewModels
{
    public class UserViewModel
    {
        public Festivalier Festivalier { get; set; }
        public Organisateur Organisateur { get; set; }
        public Artiste Artiste { get; set; }
        public bool Authentifier { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FestivalAPI.Models
{
    public class FestivalData
    {
        public IEnumerable<Festival> Festi { get; set; }
        public IEnumerable<Scene> Scenes { get; set; }
        public IEnumerable<Organisateur> Organisateurs { get; set;}
        public IEnumerable<Hebergement> Hebergements { get; set; }
        public IEnumerable<Tarif> Tarifs { get; set; }
        public IEnumerable<Artiste> Artistes { get; set; }
        public IEnumerable<Festivalier> Festivaliers { get; set; }
    }
}

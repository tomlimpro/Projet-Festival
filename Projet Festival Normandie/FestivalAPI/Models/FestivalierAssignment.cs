using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FestivalAPI.Models
{
    public class FestivalierAssignment
    {
        public int FestivalID { get; set; }
        public int FestivalierID { get; set; }
        public Festival Festival { get; set; }
        public Festivalier Festivalier { get; set; }

    }
}

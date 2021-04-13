using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using APIFestival.Models;
namespace WebFestival.ViewModels
{
    public class UserViewModel
    {
        public User User { get; set; }
        public bool Authentifie { get; set; }
    }
}

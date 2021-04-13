using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using APIFestival.Models;

namespace APIFestival.Data
{
    public class APIFestivalContext : DbContext
    {
        public APIFestivalContext (DbContextOptions<APIFestivalContext> options)
            : base(options)
        {
        }

        public DbSet<APIFestival.Models.Gestionnaire> Gestionnaire { get; set; }

        public DbSet<APIFestival.Models.User> User { get; set; }

        public DbSet<APIFestival.Models.Organisateur> Organisateur { get; set; }
    }
}

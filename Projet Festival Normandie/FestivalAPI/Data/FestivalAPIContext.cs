using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using FestivalAPI.Models;

namespace FestivalAPI.Data
{
    public class FestivalAPIContext : DbContext
    {
       
        public FestivalAPIContext()
        {

        }
        public FestivalAPIContext (DbContextOptions<FestivalAPIContext> options)
            : base(options)
        {
        }

        public DbSet<FestivalAPI.Models.Festival> Festival { get; set; }

        public DbSet<FestivalAPI.Models.Organisateur> Organisateur { get; set; }
    

        

        /*
        protected override void OnConfiguring(DbContextOptionsBuilder options)
    => options.UseSqlite("DataSource=app.db"); */
    }
}

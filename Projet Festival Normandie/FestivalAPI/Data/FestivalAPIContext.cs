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

        public DbSet<FestivalAPI.Models.Festival> Festivals { get; set; }
        public DbSet<FestivalAPI.Models.Gestionnaire> Gestionnaire{ get; set; }
        public DbSet<FestivalAPI.Models.Organisateur> Organisateurs { get; set; }

        public DbSet<FestivalAPI.Models.Artiste> Artistes { get; set; }

        public DbSet<FestivalAPI.Models.Hebergement> Hebergements { get; set; }

        public DbSet<FestivalAPI.Models.Scene> Scenes { get; set; }

        public DbSet<FestivalAPI.Models.Tarif> Tarifs { get; set; }
        public DbSet<Festivalier> Festivaliers { get; set; }
        public DbSet<FestivalierAssignment> FestivalierAssignments { get; set; }
       

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Festival>().ToTable("Festival");
            modelBuilder.Entity<Festivalier>().ToTable("Festivalier");
            modelBuilder.Entity<Organisateur>().ToTable("Organisateur");
            modelBuilder.Entity<Artiste>().ToTable("Artiste");
            modelBuilder.Entity<Tarif>().ToTable("Tarif");
            modelBuilder.Entity<Scene>().ToTable("Scene");
            modelBuilder.Entity<Hebergement>().ToTable("Hebergement");
            modelBuilder.Entity<FestivalierAssignment>().ToTable("FestivalierAssignment");

            modelBuilder.Entity<FestivalierAssignment>()
                .HasKey(c => new { c.FestivalID, c.FestivalierID });



        }




        /*
        protected override void OnConfiguring(DbContextOptionsBuilder options)
    => options.UseSqlite("DataSource=app.db"); */
    }
}

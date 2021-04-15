﻿// <auto-generated />
using FestivalAPI.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace FestivalAPI.Migrations
{
    [DbContext(typeof(FestivalAPIContext))]
    [Migration("20210414232758_lol")]
    partial class lol
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.13")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("FestivalAPI.Models.Festival", b =>
                {
                    b.Property<int>("FestivalId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Lieu")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nom_Festival")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("FestivalId");

                    b.ToTable("Festival");
                });

            modelBuilder.Entity("FestivalAPI.Models.Organisateur", b =>
                {
                    b.Property<int>("IdOrganisateur")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("FestivalId")
                        .HasColumnType("int");

                    b.Property<string>("Mot_de_passe")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nom")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Prenom")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("IdOrganisateur");

                    b.HasIndex("FestivalId");

                    b.ToTable("Organisateur");
                });

            modelBuilder.Entity("FestivalAPI.Models.Organisateur", b =>
                {
                    b.HasOne("FestivalAPI.Models.Festival", null)
                        .WithMany("Organisateurs")
                        .HasForeignKey("FestivalId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
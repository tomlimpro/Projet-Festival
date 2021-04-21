﻿// <auto-generated />
using System;
using FestivalAPI.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace FestivalAPI.Migrations
{
    [DbContext(typeof(FestivalAPIContext))]
    [Migration("20210419195930_test")]
    partial class test
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.13")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("FestivalAPI.Models.Artiste", b =>
                {
                    b.Property<int>("ArtisteID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Descriptif_Artiste")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ExtraitMusical_Artiste")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nom_Artiste")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Pays_Artiste")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("SceneID")
                        .HasColumnType("int");

                    b.Property<string>("Style_Artiste")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ArtisteID");

                    b.HasIndex("SceneID");

                    b.ToTable("Artiste");
                });

            modelBuilder.Entity("FestivalAPI.Models.Festival", b =>
                {
                    b.Property<int>("FestivalID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("DateDebut")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DateFin")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Logo")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nom_Festival")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Ville")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("FestivalID");

                    b.ToTable("Festival");
                });

            modelBuilder.Entity("FestivalAPI.Models.Hebergement", b =>
                {
                    b.Property<int>("HebergementID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("FestivalID")
                        .HasColumnType("int");

                    b.Property<string>("LienHebergement")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TypeHebergement")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("HebergementID");

                    b.HasIndex("FestivalID");

                    b.ToTable("Hebergement");
                });

            modelBuilder.Entity("FestivalAPI.Models.Organisateur", b =>
                {
                    b.Property<int>("OrganisateurID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("FestivalID")
                        .HasColumnType("int");

                    b.Property<string>("Mot_de_passe")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nom")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Prenom")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("OrganisateurID");

                    b.HasIndex("FestivalID");

                    b.ToTable("Organisateur");
                });

            modelBuilder.Entity("FestivalAPI.Models.Scene", b =>
                {
                    b.Property<int>("SceneID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Accessibilite")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Capacite")
                        .HasColumnType("int");

                    b.Property<int>("FestivalID")
                        .HasColumnType("int");

                    b.Property<string>("Nom_Scene")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("SceneID");

                    b.HasIndex("FestivalID");

                    b.ToTable("Scene");
                });

            modelBuilder.Entity("FestivalAPI.Models.Tarif", b =>
                {
                    b.Property<int>("TarifID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("FestivalID")
                        .HasColumnType("int");

                    b.Property<string>("NomTarif")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("PrixTarif")
                        .HasColumnType("int");

                    b.HasKey("TarifID");

                    b.HasIndex("FestivalID");

                    b.ToTable("Tarif");
                });

            modelBuilder.Entity("FestivalAPI.Models.Artiste", b =>
                {
                    b.HasOne("FestivalAPI.Models.Scene", "Scene")
                        .WithMany("Artistes")
                        .HasForeignKey("SceneID");
                });

            modelBuilder.Entity("FestivalAPI.Models.Hebergement", b =>
                {
                    b.HasOne("FestivalAPI.Models.Festival", "Festival")
                        .WithMany("Hebergement")
                        .HasForeignKey("FestivalID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("FestivalAPI.Models.Organisateur", b =>
                {
                    b.HasOne("FestivalAPI.Models.Festival", "Festival")
                        .WithMany("Organisateur")
                        .HasForeignKey("FestivalID");
                });

            modelBuilder.Entity("FestivalAPI.Models.Scene", b =>
                {
                    b.HasOne("FestivalAPI.Models.Festival", "Festival")
                        .WithMany("Scene")
                        .HasForeignKey("FestivalID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("FestivalAPI.Models.Tarif", b =>
                {
                    b.HasOne("FestivalAPI.Models.Festival", "Festival")
                        .WithMany("Tarif")
                        .HasForeignKey("FestivalID");
                });
#pragma warning restore 612, 618
        }
    }
}

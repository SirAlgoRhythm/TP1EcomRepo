﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using TheWebsite;

#nullable disable

namespace TheWebsite.Migrations
{
    [DbContext(typeof(TheWebsiteContext))]
    [Migration("20230301145401_AjoutSolde")]
    partial class AjoutSolde
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("TheWebsite.Models.Facture", b =>
                {
                    b.Property<Guid>("FactureId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("DateTimeDay")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("UtilisateurId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("FactureId");

                    b.HasIndex("UtilisateurId");

                    b.ToTable("Factures");
                });

            modelBuilder.Entity("TheWebsite.Models.Produit", b =>
                {
                    b.Property<Guid>("ProduitId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Categorie")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Gender")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ImageURL")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("Price")
                        .HasColumnType("float");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Vendor")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ProduitId");

                    b.ToTable("Produits");
                });

            modelBuilder.Entity("TheWebsite.Models.ProduitPanier", b =>
                {
                    b.Property<Guid>("ProduitPanierId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("FactureId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("Number")
                        .HasColumnType("int");

                    b.Property<Guid>("ProduitId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("ProduitPanierId");

                    b.HasIndex("FactureId");

                    b.HasIndex("ProduitId");

                    b.ToTable("ProduitsPanier");
                });

            modelBuilder.Entity("TheWebsite.Models.StatistiqueClient", b =>
                {
                    b.Property<Guid>("StatistiqueClientId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("TotalArticleBought")
                        .HasColumnType("int");

                    b.Property<double>("TotalCashSpent")
                        .HasColumnType("float");

                    b.HasKey("StatistiqueClientId");

                    b.ToTable("StatistiqueClients");
                });

            modelBuilder.Entity("TheWebsite.Models.StatistiqueVendeur", b =>
                {
                    b.Property<Guid>("StatistiqueVendeurId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<double>("Profit")
                        .HasColumnType("float");

                    b.Property<int>("TotalArticleSold")
                        .HasColumnType("int");

                    b.Property<double>("TotalCashReceved")
                        .HasColumnType("float");

                    b.HasKey("StatistiqueVendeurId");

                    b.ToTable("StatistiqueVendeurs");
                });

            modelBuilder.Entity("TheWebsite.Models.Utilisateur", b =>
                {
                    b.Property<Guid>("UtilisateurId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("IsVendor")
                        .HasColumnType("bit");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PasswordHash")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<float>("Solde")
                        .HasColumnType("real");

                    b.HasKey("UtilisateurId");

                    b.ToTable("Utilisateurs");
                });

            modelBuilder.Entity("TheWebsite.Models.Facture", b =>
                {
                    b.HasOne("TheWebsite.Models.Utilisateur", "Utilisateur")
                        .WithMany()
                        .HasForeignKey("UtilisateurId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Utilisateur");
                });

            modelBuilder.Entity("TheWebsite.Models.ProduitPanier", b =>
                {
                    b.HasOne("TheWebsite.Models.Facture", "Facture")
                        .WithMany("ProduitPanierList")
                        .HasForeignKey("FactureId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("TheWebsite.Models.Produit", "Produit")
                        .WithMany()
                        .HasForeignKey("ProduitId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Facture");

                    b.Navigation("Produit");
                });

            modelBuilder.Entity("TheWebsite.Models.Facture", b =>
                {
                    b.Navigation("ProduitPanierList");
                });
#pragma warning restore 612, 618
        }
    }
}

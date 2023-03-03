using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace TheWebsite.Migrations
{
    /// <inheritdoc />
    public partial class AjoutQuantiteProduit : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Utilisateurs",
                keyColumn: "UtilisateurId",
                keyValue: new Guid("12ade67d-6880-493e-8df3-59c13e0f0857"));

            migrationBuilder.DeleteData(
                table: "Utilisateurs",
                keyColumn: "UtilisateurId",
                keyValue: new Guid("7bd3ac5d-06eb-4ff9-9b49-680d490b41b1"));

            migrationBuilder.DropColumn(
                name: "Number",
                table: "ProduitsPanier");

            migrationBuilder.AddColumn<int>(
                name: "Quantite",
                table: "Produits",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.InsertData(
                table: "Utilisateurs",
                columns: new[] { "UtilisateurId", "IsVendor", "LastName", "Name", "PasswordHash", "Solde" },
                values: new object[,]
                {
                    { new Guid("5e1a80be-47cd-4e38-8cc8-b53804a5c9ac"), true, "nom2", "prenom2", "motdepasse", 13f },
                    { new Guid("fc9894f9-c515-40ce-851a-eaad3f9b3013"), false, "nom1", "prenom1", "motdepasse", 123f }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Utilisateurs",
                keyColumn: "UtilisateurId",
                keyValue: new Guid("5e1a80be-47cd-4e38-8cc8-b53804a5c9ac"));

            migrationBuilder.DeleteData(
                table: "Utilisateurs",
                keyColumn: "UtilisateurId",
                keyValue: new Guid("fc9894f9-c515-40ce-851a-eaad3f9b3013"));

            migrationBuilder.DropColumn(
                name: "Quantite",
                table: "Produits");

            migrationBuilder.AddColumn<int>(
                name: "Number",
                table: "ProduitsPanier",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.InsertData(
                table: "Utilisateurs",
                columns: new[] { "UtilisateurId", "IsVendor", "LastName", "Name", "PasswordHash", "Solde" },
                values: new object[,]
                {
                    { new Guid("12ade67d-6880-493e-8df3-59c13e0f0857"), false, "nom1", "prenom1", "motdepasse", 123f },
                    { new Guid("7bd3ac5d-06eb-4ff9-9b49-680d490b41b1"), true, "nom2", "prenom2", "motdepasse", 13f }
                });
        }
    }
}

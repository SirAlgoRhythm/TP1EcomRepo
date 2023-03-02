using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace TheWebsite.Migrations
{
    /// <inheritdoc />
    public partial class AjoutUtilisateurIdDansProduit : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Utilisateurs",
                keyColumn: "UtilisateurId",
                keyValue: new Guid("490cbbd8-10f3-489d-970f-be6a6f5ba763"));

            migrationBuilder.DeleteData(
                table: "Utilisateurs",
                keyColumn: "UtilisateurId",
                keyValue: new Guid("a0d7e497-1e31-4a83-9c34-153f3083123a"));

            migrationBuilder.AddColumn<Guid>(
                name: "UtilisateurId",
                table: "Produits",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.InsertData(
                table: "Utilisateurs",
                columns: new[] { "UtilisateurId", "IsVendor", "LastName", "Name", "PasswordHash", "Solde" },
                values: new object[,]
                {
                    { new Guid("12ade67d-6880-493e-8df3-59c13e0f0857"), false, "nom1", "prenom1", "motdepasse", 123f },
                    { new Guid("7bd3ac5d-06eb-4ff9-9b49-680d490b41b1"), true, "nom2", "prenom2", "motdepasse", 13f }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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
                name: "UtilisateurId",
                table: "Produits");

            migrationBuilder.InsertData(
                table: "Utilisateurs",
                columns: new[] { "UtilisateurId", "IsVendor", "LastName", "Name", "PasswordHash", "Solde" },
                values: new object[,]
                {
                    { new Guid("490cbbd8-10f3-489d-970f-be6a6f5ba763"), false, "nom1", "prenom1", "motdepasse", 123f },
                    { new Guid("a0d7e497-1e31-4a83-9c34-153f3083123a"), true, "nom2", "prenom2", "motdepasse", 13f }
                });
        }
    }
}

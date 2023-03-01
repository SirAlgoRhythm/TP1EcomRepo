using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace TheWebsite.Migrations
{
    /// <inheritdoc />
    public partial class InitialData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Utilisateurs",
                columns: new[] { "UtilisateurId", "IsVendor", "LastName", "Name", "PasswordHash", "Solde" },
                values: new object[,]
                {
                    { new Guid("490cbbd8-10f3-489d-970f-be6a6f5ba763"), false, "nom1", "prenom1", "motdepasse", 123f },
                    { new Guid("a0d7e497-1e31-4a83-9c34-153f3083123a"), true, "nom2", "prenom2", "motdepasse", 13f }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Utilisateurs",
                keyColumn: "UtilisateurId",
                keyValue: new Guid("490cbbd8-10f3-489d-970f-be6a6f5ba763"));

            migrationBuilder.DeleteData(
                table: "Utilisateurs",
                keyColumn: "UtilisateurId",
                keyValue: new Guid("a0d7e497-1e31-4a83-9c34-153f3083123a"));
        }
    }
}

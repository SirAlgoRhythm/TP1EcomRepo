using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace TheWebsite.Migrations
{
    /// <inheritdoc />
    public partial class TestOneToOne : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProduitsPanier_Factures_FactureId",
                table: "ProduitsPanier");

            migrationBuilder.DropIndex(
                name: "IX_ProduitsPanier_FactureId",
                table: "ProduitsPanier");

            migrationBuilder.DeleteData(
                table: "Utilisateurs",
                keyColumn: "UtilisateurId",
                keyValue: new Guid("265f5f7e-53c6-4b29-a11e-9e4399136873"));

            migrationBuilder.DeleteData(
                table: "Utilisateurs",
                keyColumn: "UtilisateurId",
                keyValue: new Guid("db1a0ce9-87ef-48f8-b438-41a36a20e241"));

            migrationBuilder.DropColumn(
                name: "FactureId",
                table: "ProduitsPanier");

            migrationBuilder.AddColumn<Guid>(
                name: "ProduitPanierId",
                table: "Factures",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.InsertData(
                table: "Utilisateurs",
                columns: new[] { "UtilisateurId", "IsVendor", "LastName", "Name", "PasswordHash", "Solde" },
                values: new object[,]
                {
                    { new Guid("81502143-62b3-446c-b172-f963e28d4ec4"), true, "nom2", "prenom2", "motdepasse", 13f },
                    { new Guid("ddfb06ae-6499-4dc5-88db-43b27620933a"), false, "nom1", "prenom1", "motdepasse", 123f }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Factures_ProduitPanierId",
                table: "Factures",
                column: "ProduitPanierId");

            migrationBuilder.AddForeignKey(
                name: "FK_Factures_ProduitsPanier_ProduitPanierId",
                table: "Factures",
                column: "ProduitPanierId",
                principalTable: "ProduitsPanier",
                principalColumn: "ProduitPanierId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Factures_ProduitsPanier_ProduitPanierId",
                table: "Factures");

            migrationBuilder.DropIndex(
                name: "IX_Factures_ProduitPanierId",
                table: "Factures");

            migrationBuilder.DeleteData(
                table: "Utilisateurs",
                keyColumn: "UtilisateurId",
                keyValue: new Guid("81502143-62b3-446c-b172-f963e28d4ec4"));

            migrationBuilder.DeleteData(
                table: "Utilisateurs",
                keyColumn: "UtilisateurId",
                keyValue: new Guid("ddfb06ae-6499-4dc5-88db-43b27620933a"));

            migrationBuilder.DropColumn(
                name: "ProduitPanierId",
                table: "Factures");

            migrationBuilder.AddColumn<Guid>(
                name: "FactureId",
                table: "ProduitsPanier",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.InsertData(
                table: "Utilisateurs",
                columns: new[] { "UtilisateurId", "IsVendor", "LastName", "Name", "PasswordHash", "Solde" },
                values: new object[,]
                {
                    { new Guid("265f5f7e-53c6-4b29-a11e-9e4399136873"), true, "nom2", "prenom2", "motdepasse", 13f },
                    { new Guid("db1a0ce9-87ef-48f8-b438-41a36a20e241"), false, "nom1", "prenom1", "motdepasse", 123f }
                });

            migrationBuilder.CreateIndex(
                name: "IX_ProduitsPanier_FactureId",
                table: "ProduitsPanier",
                column: "FactureId");

            migrationBuilder.AddForeignKey(
                name: "FK_ProduitsPanier_Factures_FactureId",
                table: "ProduitsPanier",
                column: "FactureId",
                principalTable: "Factures",
                principalColumn: "FactureId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

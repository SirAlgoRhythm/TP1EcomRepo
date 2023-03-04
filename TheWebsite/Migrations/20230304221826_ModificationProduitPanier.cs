using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace TheWebsite.Migrations
{
    /// <inheritdoc />
    public partial class ModificationProduitPanier : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProduitsPanier_Produits_ProduitId",
                table: "ProduitsPanier");

            migrationBuilder.DeleteData(
                table: "Utilisateurs",
                keyColumn: "UtilisateurId",
                keyValue: new Guid("5e1a80be-47cd-4e38-8cc8-b53804a5c9ac"));

            migrationBuilder.DeleteData(
                table: "Utilisateurs",
                keyColumn: "UtilisateurId",
                keyValue: new Guid("fc9894f9-c515-40ce-851a-eaad3f9b3013"));

            migrationBuilder.RenameColumn(
                name: "ProduitId",
                table: "ProduitsPanier",
                newName: "UtilisateurId");

            migrationBuilder.RenameIndex(
                name: "IX_ProduitsPanier_ProduitId",
                table: "ProduitsPanier",
                newName: "IX_ProduitsPanier_UtilisateurId");

            migrationBuilder.AddColumn<Guid>(
                name: "ProduitPanierId",
                table: "Produits",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.InsertData(
                table: "Utilisateurs",
                columns: new[] { "UtilisateurId", "IsVendor", "LastName", "Name", "PasswordHash", "Solde" },
                values: new object[,]
                {
                    { new Guid("265f5f7e-53c6-4b29-a11e-9e4399136873"), true, "nom2", "prenom2", "motdepasse", 13f },
                    { new Guid("db1a0ce9-87ef-48f8-b438-41a36a20e241"), false, "nom1", "prenom1", "motdepasse", 123f }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Produits_ProduitPanierId",
                table: "Produits",
                column: "ProduitPanierId");

            migrationBuilder.AddForeignKey(
                name: "FK_Produits_ProduitsPanier_ProduitPanierId",
                table: "Produits",
                column: "ProduitPanierId",
                principalTable: "ProduitsPanier",
                principalColumn: "ProduitPanierId");

            migrationBuilder.AddForeignKey(
                name: "FK_ProduitsPanier_Utilisateurs_UtilisateurId",
                table: "ProduitsPanier",
                column: "UtilisateurId",
                principalTable: "Utilisateurs",
                principalColumn: "UtilisateurId",
                onDelete: ReferentialAction.NoAction);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Produits_ProduitsPanier_ProduitPanierId",
                table: "Produits");

            migrationBuilder.DropForeignKey(
                name: "FK_ProduitsPanier_Utilisateurs_UtilisateurId",
                table: "ProduitsPanier");

            migrationBuilder.DropIndex(
                name: "IX_Produits_ProduitPanierId",
                table: "Produits");

            migrationBuilder.DeleteData(
                table: "Utilisateurs",
                keyColumn: "UtilisateurId",
                keyValue: new Guid("265f5f7e-53c6-4b29-a11e-9e4399136873"));

            migrationBuilder.DeleteData(
                table: "Utilisateurs",
                keyColumn: "UtilisateurId",
                keyValue: new Guid("db1a0ce9-87ef-48f8-b438-41a36a20e241"));

            migrationBuilder.DropColumn(
                name: "ProduitPanierId",
                table: "Produits");

            migrationBuilder.RenameColumn(
                name: "UtilisateurId",
                table: "ProduitsPanier",
                newName: "ProduitId");

            migrationBuilder.RenameIndex(
                name: "IX_ProduitsPanier_UtilisateurId",
                table: "ProduitsPanier",
                newName: "IX_ProduitsPanier_ProduitId");

            migrationBuilder.InsertData(
                table: "Utilisateurs",
                columns: new[] { "UtilisateurId", "IsVendor", "LastName", "Name", "PasswordHash", "Solde" },
                values: new object[,]
                {
                    { new Guid("5e1a80be-47cd-4e38-8cc8-b53804a5c9ac"), true, "nom2", "prenom2", "motdepasse", 13f },
                    { new Guid("fc9894f9-c515-40ce-851a-eaad3f9b3013"), false, "nom1", "prenom1", "motdepasse", 123f }
                });

            migrationBuilder.AddForeignKey(
                name: "FK_ProduitsPanier_Produits_ProduitId",
                table: "ProduitsPanier",
                column: "ProduitId",
                principalTable: "Produits",
                principalColumn: "ProduitId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

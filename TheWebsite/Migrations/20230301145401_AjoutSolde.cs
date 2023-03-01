using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TheWebsite.Migrations
{
    /// <inheritdoc />
    public partial class AjoutSolde : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<float>(
                name: "Solde",
                table: "Utilisateurs",
                type: "real",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AddColumn<Guid>(
                name: "UtilisateurId",
                table: "Factures",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_Factures_UtilisateurId",
                table: "Factures",
                column: "UtilisateurId");

            migrationBuilder.AddForeignKey(
                name: "FK_Factures_Utilisateurs_UtilisateurId",
                table: "Factures",
                column: "UtilisateurId",
                principalTable: "Utilisateurs",
                principalColumn: "UtilisateurId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Factures_Utilisateurs_UtilisateurId",
                table: "Factures");

            migrationBuilder.DropIndex(
                name: "IX_Factures_UtilisateurId",
                table: "Factures");

            migrationBuilder.DropColumn(
                name: "Solde",
                table: "Utilisateurs");

            migrationBuilder.DropColumn(
                name: "UtilisateurId",
                table: "Factures");
        }
    }
}

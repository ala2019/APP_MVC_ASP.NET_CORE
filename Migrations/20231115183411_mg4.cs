using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TP4.Migrations
{
    public partial class mg4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "EtudiantId",
                table: "Inscription",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "MatiereId",
                table: "Inscription",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "GroupeId",
                table: "Etudiant",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Inscription_EtudiantId",
                table: "Inscription",
                column: "EtudiantId");

            migrationBuilder.CreateIndex(
                name: "IX_Inscription_MatiereId",
                table: "Inscription",
                column: "MatiereId");

            migrationBuilder.CreateIndex(
                name: "IX_Etudiant_GroupeId",
                table: "Etudiant",
                column: "GroupeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Etudiant_Groupe_GroupeId",
                table: "Etudiant",
                column: "GroupeId",
                principalTable: "Groupe",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Inscription_Etudiant_EtudiantId",
                table: "Inscription",
                column: "EtudiantId",
                principalTable: "Etudiant",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Inscription_Matiére_MatiereId",
                table: "Inscription",
                column: "MatiereId",
                principalTable: "Matiére",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Etudiant_Groupe_GroupeId",
                table: "Etudiant");

            migrationBuilder.DropForeignKey(
                name: "FK_Inscription_Etudiant_EtudiantId",
                table: "Inscription");

            migrationBuilder.DropForeignKey(
                name: "FK_Inscription_Matiére_MatiereId",
                table: "Inscription");

            migrationBuilder.DropIndex(
                name: "IX_Inscription_EtudiantId",
                table: "Inscription");

            migrationBuilder.DropIndex(
                name: "IX_Inscription_MatiereId",
                table: "Inscription");

            migrationBuilder.DropIndex(
                name: "IX_Etudiant_GroupeId",
                table: "Etudiant");

            migrationBuilder.DropColumn(
                name: "EtudiantId",
                table: "Inscription");

            migrationBuilder.DropColumn(
                name: "MatiereId",
                table: "Inscription");

            migrationBuilder.DropColumn(
                name: "GroupeId",
                table: "Etudiant");
        }
    }
}

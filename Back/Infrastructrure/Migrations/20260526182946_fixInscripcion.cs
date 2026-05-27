using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class fixInscripcion : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Inscripcion_Cancha_IdCancha",
                table: "Inscripcion");

            migrationBuilder.DropForeignKey(
                name: "FK_Inscripcion_Profesores_profesorDni",
                table: "Inscripcion");

            migrationBuilder.DropIndex(
                name: "IX_Inscripcion_IdCancha",
                table: "Inscripcion");

            migrationBuilder.DropIndex(
                name: "IX_Inscripcion_profesorDni",
                table: "Inscripcion");

            migrationBuilder.DropColumn(
                name: "IdCancha",
                table: "Inscripcion");

            migrationBuilder.DropColumn(
                name: "profesorDni",
                table: "Inscripcion");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "IdCancha",
                table: "Inscripcion",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "profesorDni",
                table: "Inscripcion",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Inscripcion_IdCancha",
                table: "Inscripcion",
                column: "IdCancha");

            migrationBuilder.CreateIndex(
                name: "IX_Inscripcion_profesorDni",
                table: "Inscripcion",
                column: "profesorDni");

            migrationBuilder.AddForeignKey(
                name: "FK_Inscripcion_Cancha_IdCancha",
                table: "Inscripcion",
                column: "IdCancha",
                principalTable: "Cancha",
                principalColumn: "IdCancha",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Inscripcion_Profesores_profesorDni",
                table: "Inscripcion",
                column: "profesorDni",
                principalTable: "Profesores",
                principalColumn: "Dni",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

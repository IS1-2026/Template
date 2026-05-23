using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class profesorEntrenamientoFix : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Clase_Profesores_IdProfesor",
                table: "Clase");

            migrationBuilder.DropIndex(
                name: "IX_Clase_IdProfesor",
                table: "Clase");

            migrationBuilder.RenameColumn(
                name: "IdProfesor",
                table: "Clase",
                newName: "IdActividad");

            migrationBuilder.AddColumn<int>(
                name: "Cupo",
                table: "Entrenamiento",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "DniProfesor",
                table: "Clase",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Clase_DniProfesor",
                table: "Clase",
                column: "DniProfesor");

            migrationBuilder.AddForeignKey(
                name: "FK_Clase_Profesores_DniProfesor",
                table: "Clase",
                column: "DniProfesor",
                principalTable: "Profesores",
                principalColumn: "Dni",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Clase_Profesores_DniProfesor",
                table: "Clase");

            migrationBuilder.DropIndex(
                name: "IX_Clase_DniProfesor",
                table: "Clase");

            migrationBuilder.DropColumn(
                name: "Cupo",
                table: "Entrenamiento");

            migrationBuilder.DropColumn(
                name: "DniProfesor",
                table: "Clase");

            migrationBuilder.RenameColumn(
                name: "IdActividad",
                table: "Clase",
                newName: "IdProfesor");

            migrationBuilder.CreateIndex(
                name: "IX_Clase_IdProfesor",
                table: "Clase",
                column: "IdProfesor");

            migrationBuilder.AddForeignKey(
                name: "FK_Clase_Profesores_IdProfesor",
                table: "Clase",
                column: "IdProfesor",
                principalTable: "Profesores",
                principalColumn: "Dni",
                onDelete: ReferentialAction.Restrict);
        }
    }
}

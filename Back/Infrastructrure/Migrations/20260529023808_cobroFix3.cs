using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class cobroFix3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Cobro_IdReserva",
                table: "Cobro");

            migrationBuilder.AlterColumn<int>(
                name: "IdReserva",
                table: "Cobro",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "IdInscripcion",
                table: "Cobro",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Cobro_IdInscripcion",
                table: "Cobro",
                column: "IdInscripcion",
                unique: true,
                filter: "[IdInscripcion] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Cobro_IdReserva",
                table: "Cobro",
                column: "IdReserva",
                unique: true,
                filter: "[IdReserva] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_Cobro_Inscripcion_IdInscripcion",
                table: "Cobro",
                column: "IdInscripcion",
                principalTable: "Inscripcion",
                principalColumn: "IdInscripcion",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cobro_Inscripcion_IdInscripcion",
                table: "Cobro");

            migrationBuilder.DropIndex(
                name: "IX_Cobro_IdInscripcion",
                table: "Cobro");

            migrationBuilder.DropIndex(
                name: "IX_Cobro_IdReserva",
                table: "Cobro");

            migrationBuilder.DropColumn(
                name: "IdInscripcion",
                table: "Cobro");

            migrationBuilder.AlterColumn<int>(
                name: "IdReserva",
                table: "Cobro",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Cobro_IdReserva",
                table: "Cobro",
                column: "IdReserva");
        }
    }
}

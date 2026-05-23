using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class horarioCanchaTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Disponibilidad",
                table: "Cancha");

            migrationBuilder.CreateTable(
                name: "HorarioCancha",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdCancha = table.Column<int>(type: "int", nullable: false),
                    Dia = table.Column<int>(type: "int", nullable: false),
                    HoraInicio = table.Column<TimeSpan>(type: "time", nullable: false),
                    HoraFin = table.Column<TimeSpan>(type: "time", nullable: false),
                    Disponible = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HorarioCancha", x => x.Id);
                    table.ForeignKey(
                        name: "FK_HorarioCancha_Cancha_IdCancha",
                        column: x => x.IdCancha,
                        principalTable: "Cancha",
                        principalColumn: "IdCancha",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_HorarioCancha_IdCancha",
                table: "HorarioCancha",
                column: "IdCancha");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "HorarioCancha");

            migrationBuilder.AddColumn<string>(
                name: "Disponibilidad",
                table: "Cancha",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}

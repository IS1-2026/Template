using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class reservaFix2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Disponible",
                table: "HorarioCancha");

            migrationBuilder.AddColumn<DateOnly>(
                name: "Fecha",
                table: "Reserva",
                type: "date",
                nullable: false,
                defaultValue: new DateOnly(1, 1, 1));

            migrationBuilder.CreateIndex(
                name: "IX_Reserva_IdCanchaHorario",
                table: "Reserva",
                column: "IdCanchaHorario");

            migrationBuilder.AddForeignKey(
                name: "FK_Reserva_HorarioCancha_IdCanchaHorario",
                table: "Reserva",
                column: "IdCanchaHorario",
                principalTable: "HorarioCancha",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Reserva_HorarioCancha_IdCanchaHorario",
                table: "Reserva");

            migrationBuilder.DropIndex(
                name: "IX_Reserva_IdCanchaHorario",
                table: "Reserva");

            migrationBuilder.DropColumn(
                name: "Fecha",
                table: "Reserva");

            migrationBuilder.AddColumn<bool>(
                name: "Disponible",
                table: "HorarioCancha",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }
    }
}

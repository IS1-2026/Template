using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class idCanchaHorarioFix : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FechaRes",
                table: "Reserva");

            migrationBuilder.DropColumn(
                name: "HorarioFin",
                table: "Reserva");

            migrationBuilder.DropColumn(
                name: "HorarioInicio",
                table: "Reserva");

            migrationBuilder.AddColumn<int>(
                name: "IdCanchaHorario",
                table: "Reserva",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IdCanchaHorario",
                table: "Reserva");

            migrationBuilder.AddColumn<DateTime>(
                name: "FechaRes",
                table: "Reserva",
                type: "datetime",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<TimeSpan>(
                name: "HorarioFin",
                table: "Reserva",
                type: "time",
                nullable: false,
                defaultValue: new TimeSpan(0, 0, 0, 0, 0));

            migrationBuilder.AddColumn<TimeSpan>(
                name: "HorarioInicio",
                table: "Reserva",
                type: "time",
                nullable: false,
                defaultValue: new TimeSpan(0, 0, 0, 0, 0));
        }
    }
}

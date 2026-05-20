using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Administradores",
                columns: table => new
                {
                    Dni = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Administradores", x => x.Dni);
                });

            migrationBuilder.CreateTable(
                name: "Asistencia",
                columns: table => new
                {
                    IdAsistencia = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DniCliente = table.Column<int>(type: "int", nullable: false),
                    IdClase = table.Column<int>(type: "int", nullable: false),
                    Presente = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Asistencia", x => x.IdAsistencia);
                });

            migrationBuilder.CreateTable(
                name: "Clientes",
                columns: table => new
                {
                    Dni = table.Column<int>(type: "int", nullable: false),
                    EsSocio = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clientes", x => x.Dni);
                });

            migrationBuilder.CreateTable(
                name: "Competencia",
                columns: table => new
                {
                    IdCompeticion = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    Descripcion = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Cupos = table.Column<int>(type: "int", nullable: false),
                    Precio = table.Column<decimal>(type: "decimal(10,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Competencia", x => x.IdCompeticion);
                });

            migrationBuilder.CreateTable(
                name: "Descuento",
                columns: table => new
                {
                    IdDescuento = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Valor = table.Column<double>(type: "float", nullable: false),
                    Descripcion = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    FechaInicio = table.Column<DateTime>(type: "datetime", nullable: false),
                    FechaFin = table.Column<DateTime>(type: "datetime", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Descuento", x => x.IdDescuento);
                });

            migrationBuilder.CreateTable(
                name: "Ligas",
                columns: table => new
                {
                    IdCompeticion = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ligas", x => x.IdCompeticion);
                });

            migrationBuilder.CreateTable(
                name: "Reporte",
                columns: table => new
                {
                    IdReporte = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TipoReporte = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    FechaEmision = table.Column<DateTime>(type: "datetime", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reporte", x => x.IdReporte);
                });

            migrationBuilder.CreateTable(
                name: "TipoCancha",
                columns: table => new
                {
                    IdTipoCancha = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Superficie = table.Column<int>(type: "int", nullable: false),
                    Capacidad = table.Column<int>(type: "int", nullable: false),
                    Duracion = table.Column<int>(type: "int", nullable: false),
                    Precio = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TipoCancha", x => x.IdTipoCancha);
                });

            migrationBuilder.CreateTable(
                name: "Usuario",
                columns: table => new
                {
                    Dni = table.Column<int>(type: "int", nullable: false),
                    Nombre = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Apellido = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Localidad = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    Pais = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    Correo = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Password = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    FechaNac = table.Column<DateTime>(type: "datetime", nullable: false),
                    Estado = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuario", x => x.Dni);
                });

            migrationBuilder.CreateTable(
                name: "Equipo",
                columns: table => new
                {
                    IdEquipo = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    Victorias = table.Column<int>(type: "int", nullable: false),
                    Derrotas = table.Column<int>(type: "int", nullable: false),
                    Estado = table.Column<bool>(type: "bit", nullable: false),
                    CompetenciaIdCompeticion = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Equipo", x => x.IdEquipo);
                    table.ForeignKey(
                        name: "FK_Equipo_Competencia_CompetenciaIdCompeticion",
                        column: x => x.CompetenciaIdCompeticion,
                        principalTable: "Competencia",
                        principalColumn: "IdCompeticion");
                });

            migrationBuilder.CreateTable(
                name: "Torneo",
                columns: table => new
                {
                    IdCompeticion = table.Column<int>(type: "int", nullable: false),
                    FaseAct = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Torneo", x => x.IdCompeticion);
                    table.ForeignKey(
                        name: "FK_Torneo_Competencia_IdCompeticion",
                        column: x => x.IdCompeticion,
                        principalTable: "Competencia",
                        principalColumn: "IdCompeticion",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Cancha",
                columns: table => new
                {
                    IdCancha = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TipoCanchaId = table.Column<int>(type: "int", nullable: false),
                    Disponibilidad = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Estado = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cancha", x => x.IdCancha);
                    table.ForeignKey(
                        name: "FK_Cancha_TipoCancha_TipoCanchaId",
                        column: x => x.TipoCanchaId,
                        principalTable: "TipoCancha",
                        principalColumn: "IdTipoCancha",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Profesional",
                columns: table => new
                {
                    Dni = table.Column<int>(type: "int", nullable: false),
                    Certificado = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    EstaCertificado = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Profesional", x => x.Dni);
                    table.ForeignKey(
                        name: "FK_Profesional_Usuario_Dni",
                        column: x => x.Dni,
                        principalTable: "Usuario",
                        principalColumn: "Dni",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Partido",
                columns: table => new
                {
                    IdPartido = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdCompetencia = table.Column<int>(type: "int", nullable: false),
                    IdEquipoLocal = table.Column<int>(type: "int", nullable: false),
                    IdEquipoVis = table.Column<int>(type: "int", nullable: false),
                    Resultado = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    HoraInicio = table.Column<DateTime>(type: "datetime", nullable: false),
                    HoraFin = table.Column<DateTime>(type: "datetime", nullable: false),
                    EquipoIdEquipo = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Partido", x => x.IdPartido);
                    table.ForeignKey(
                        name: "FK_Partido_Competencia_IdCompetencia",
                        column: x => x.IdCompetencia,
                        principalTable: "Competencia",
                        principalColumn: "IdCompeticion",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Partido_Equipo_EquipoIdEquipo",
                        column: x => x.EquipoIdEquipo,
                        principalTable: "Equipo",
                        principalColumn: "IdEquipo");
                    table.ForeignKey(
                        name: "FK_Partido_Equipo_IdEquipoLocal",
                        column: x => x.IdEquipoLocal,
                        principalTable: "Equipo",
                        principalColumn: "IdEquipo",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Partido_Equipo_IdEquipoVis",
                        column: x => x.IdEquipoVis,
                        principalTable: "Equipo",
                        principalColumn: "IdEquipo",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Reserva",
                columns: table => new
                {
                    IdReserva = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DniCliente = table.Column<int>(type: "int", nullable: false),
                    IdCancha = table.Column<int>(type: "int", nullable: false),
                    IdDescuento = table.Column<int>(type: "int", nullable: true),
                    FechaRes = table.Column<DateTime>(type: "datetime", nullable: false),
                    HorarioInicio = table.Column<DateTime>(type: "datetime2", nullable: false),
                    HorarioFin = table.Column<DateTime>(type: "datetime2", nullable: false),
                    MontoTotal = table.Column<decimal>(type: "decimal(10,2)", nullable: false),
                    EsValida = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reserva", x => x.IdReserva);
                    table.ForeignKey(
                        name: "FK_Reserva_Cancha_IdCancha",
                        column: x => x.IdCancha,
                        principalTable: "Cancha",
                        principalColumn: "IdCancha",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Reserva_Clientes_DniCliente",
                        column: x => x.DniCliente,
                        principalTable: "Clientes",
                        principalColumn: "Dni",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Entrenadores",
                columns: table => new
                {
                    Dni = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Entrenadores", x => x.Dni);
                    table.ForeignKey(
                        name: "FK_Entrenadores_Profesional_Dni",
                        column: x => x.Dni,
                        principalTable: "Profesional",
                        principalColumn: "Dni",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Profesores",
                columns: table => new
                {
                    Dni = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Profesores", x => x.Dni);
                    table.ForeignKey(
                        name: "FK_Profesores_Profesional_Dni",
                        column: x => x.Dni,
                        principalTable: "Profesional",
                        principalColumn: "Dni",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Cobro",
                columns: table => new
                {
                    IdCobro = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdReserva = table.Column<int>(type: "int", nullable: false),
                    EstaCompleto = table.Column<bool>(type: "bit", nullable: false),
                    MontoTotal = table.Column<decimal>(type: "decimal(10,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cobro", x => x.IdCobro);
                    table.ForeignKey(
                        name: "FK_Cobro_Reserva_IdReserva",
                        column: x => x.IdReserva,
                        principalTable: "Reserva",
                        principalColumn: "IdReserva",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Entrenamiento",
                columns: table => new
                {
                    IdEntrenamiento = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DniEntrenador = table.Column<int>(type: "int", nullable: false),
                    Precio = table.Column<decimal>(type: "decimal(10,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Entrenamiento", x => x.IdEntrenamiento);
                    table.ForeignKey(
                        name: "FK_Entrenamiento_Entrenadores_DniEntrenador",
                        column: x => x.DniEntrenador,
                        principalTable: "Entrenadores",
                        principalColumn: "Dni",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Clase",
                columns: table => new
                {
                    IdClase = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Cupo = table.Column<int>(type: "int", nullable: false),
                    IdProfesor = table.Column<int>(type: "int", nullable: false),
                    Precio = table.Column<decimal>(type: "decimal(10,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clase", x => x.IdClase);
                    table.ForeignKey(
                        name: "FK_Clase_Profesores_IdProfesor",
                        column: x => x.IdProfesor,
                        principalTable: "Profesores",
                        principalColumn: "Dni",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Recibo",
                columns: table => new
                {
                    IdRecibo = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdCobro = table.Column<int>(type: "int", nullable: false),
                    IdReserva = table.Column<int>(type: "int", nullable: false),
                    MontoTotal = table.Column<decimal>(type: "decimal(10,2)", nullable: false),
                    FechaEmision = table.Column<DateTime>(type: "datetime", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Recibo", x => x.IdRecibo);
                    table.ForeignKey(
                        name: "FK_Recibo_Cobro_IdCobro",
                        column: x => x.IdCobro,
                        principalTable: "Cobro",
                        principalColumn: "IdCobro",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Recibo_Reserva_IdReserva",
                        column: x => x.IdReserva,
                        principalTable: "Reserva",
                        principalColumn: "IdReserva",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Inscripcion",
                columns: table => new
                {
                    IdInscripcion = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DniCliente = table.Column<int>(type: "int", nullable: false),
                    Horario = table.Column<DateTime>(type: "datetime", nullable: false),
                    PrecioInscr = table.Column<decimal>(type: "decimal(10,2)", nullable: false),
                    NroAct = table.Column<int>(type: "int", nullable: false),
                    IdAct = table.Column<int>(type: "int", nullable: false),
                    IdCancha = table.Column<int>(type: "int", nullable: false),
                    IdDescuento = table.Column<int>(type: "int", nullable: false),
                    claseIdClase = table.Column<int>(type: "int", nullable: true),
                    entrenamientoIdEntrenamiento = table.Column<int>(type: "int", nullable: true),
                    competenciaIdCompeticion = table.Column<int>(type: "int", nullable: true),
                    profesorDni = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Inscripcion", x => x.IdInscripcion);
                    table.ForeignKey(
                        name: "FK_Inscripcion_Cancha_IdCancha",
                        column: x => x.IdCancha,
                        principalTable: "Cancha",
                        principalColumn: "IdCancha",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Inscripcion_Clase_claseIdClase",
                        column: x => x.claseIdClase,
                        principalTable: "Clase",
                        principalColumn: "IdClase");
                    table.ForeignKey(
                        name: "FK_Inscripcion_Clientes_DniCliente",
                        column: x => x.DniCliente,
                        principalTable: "Clientes",
                        principalColumn: "Dni",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Inscripcion_Competencia_competenciaIdCompeticion",
                        column: x => x.competenciaIdCompeticion,
                        principalTable: "Competencia",
                        principalColumn: "IdCompeticion");
                    table.ForeignKey(
                        name: "FK_Inscripcion_Entrenamiento_entrenamientoIdEntrenamiento",
                        column: x => x.entrenamientoIdEntrenamiento,
                        principalTable: "Entrenamiento",
                        principalColumn: "IdEntrenamiento");
                    table.ForeignKey(
                        name: "FK_Inscripcion_Profesores_profesorDni",
                        column: x => x.profesorDni,
                        principalTable: "Profesores",
                        principalColumn: "Dni",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Cancha_TipoCanchaId",
                table: "Cancha",
                column: "TipoCanchaId");

            migrationBuilder.CreateIndex(
                name: "IX_Clase_IdProfesor",
                table: "Clase",
                column: "IdProfesor");

            migrationBuilder.CreateIndex(
                name: "IX_Cobro_IdReserva",
                table: "Cobro",
                column: "IdReserva");

            migrationBuilder.CreateIndex(
                name: "IX_Entrenamiento_DniEntrenador",
                table: "Entrenamiento",
                column: "DniEntrenador");

            migrationBuilder.CreateIndex(
                name: "IX_Equipo_CompetenciaIdCompeticion",
                table: "Equipo",
                column: "CompetenciaIdCompeticion");

            migrationBuilder.CreateIndex(
                name: "IX_Inscripcion_claseIdClase",
                table: "Inscripcion",
                column: "claseIdClase");

            migrationBuilder.CreateIndex(
                name: "IX_Inscripcion_competenciaIdCompeticion",
                table: "Inscripcion",
                column: "competenciaIdCompeticion");

            migrationBuilder.CreateIndex(
                name: "IX_Inscripcion_DniCliente",
                table: "Inscripcion",
                column: "DniCliente");

            migrationBuilder.CreateIndex(
                name: "IX_Inscripcion_entrenamientoIdEntrenamiento",
                table: "Inscripcion",
                column: "entrenamientoIdEntrenamiento");

            migrationBuilder.CreateIndex(
                name: "IX_Inscripcion_IdCancha",
                table: "Inscripcion",
                column: "IdCancha");

            migrationBuilder.CreateIndex(
                name: "IX_Inscripcion_profesorDni",
                table: "Inscripcion",
                column: "profesorDni");

            migrationBuilder.CreateIndex(
                name: "IX_Partido_EquipoIdEquipo",
                table: "Partido",
                column: "EquipoIdEquipo");

            migrationBuilder.CreateIndex(
                name: "IX_Partido_IdCompetencia",
                table: "Partido",
                column: "IdCompetencia");

            migrationBuilder.CreateIndex(
                name: "IX_Partido_IdEquipoLocal",
                table: "Partido",
                column: "IdEquipoLocal");

            migrationBuilder.CreateIndex(
                name: "IX_Partido_IdEquipoVis",
                table: "Partido",
                column: "IdEquipoVis");

            migrationBuilder.CreateIndex(
                name: "IX_Recibo_IdCobro",
                table: "Recibo",
                column: "IdCobro");

            migrationBuilder.CreateIndex(
                name: "IX_Recibo_IdReserva",
                table: "Recibo",
                column: "IdReserva");

            migrationBuilder.CreateIndex(
                name: "IX_Reserva_DniCliente",
                table: "Reserva",
                column: "DniCliente");

            migrationBuilder.CreateIndex(
                name: "IX_Reserva_IdCancha",
                table: "Reserva",
                column: "IdCancha");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Administradores");

            migrationBuilder.DropTable(
                name: "Asistencia");

            migrationBuilder.DropTable(
                name: "Descuento");

            migrationBuilder.DropTable(
                name: "Inscripcion");

            migrationBuilder.DropTable(
                name: "Ligas");

            migrationBuilder.DropTable(
                name: "Partido");

            migrationBuilder.DropTable(
                name: "Recibo");

            migrationBuilder.DropTable(
                name: "Reporte");

            migrationBuilder.DropTable(
                name: "Torneo");

            migrationBuilder.DropTable(
                name: "Clase");

            migrationBuilder.DropTable(
                name: "Entrenamiento");

            migrationBuilder.DropTable(
                name: "Equipo");

            migrationBuilder.DropTable(
                name: "Cobro");

            migrationBuilder.DropTable(
                name: "Profesores");

            migrationBuilder.DropTable(
                name: "Entrenadores");

            migrationBuilder.DropTable(
                name: "Competencia");

            migrationBuilder.DropTable(
                name: "Reserva");

            migrationBuilder.DropTable(
                name: "Profesional");

            migrationBuilder.DropTable(
                name: "Cancha");

            migrationBuilder.DropTable(
                name: "Clientes");

            migrationBuilder.DropTable(
                name: "Usuario");

            migrationBuilder.DropTable(
                name: "TipoCancha");
        }
    }
}

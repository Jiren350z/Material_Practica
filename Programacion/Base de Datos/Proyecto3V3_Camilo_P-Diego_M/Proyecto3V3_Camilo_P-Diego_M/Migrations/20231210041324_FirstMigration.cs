using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Proyecto3V3_Camilo_P_Diego_M.Migrations
{
    public partial class FirstMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Ambulancia",
                columns: table => new
                {
                    IDAmb = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Patente = table.Column<string>(type: "varchar(6)", unicode: false, maxLength: 6, nullable: true),
                    Marca = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: true),
                    Modelo = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: true),
                    Ubicación_actual = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: true),
                    Disponibilidad = table.Column<bool>(type: "bit", nullable: false),
                    Hora_de_llamada = table.Column<TimeSpan>(type: "time", nullable: true),
                    Día_de_llamada = table.Column<int>(type: "int", nullable: true),
                    Mes_de_llamada = table.Column<int>(type: "int", nullable: true),
                    Año_de_llamada = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Ambulanc__932197C298B23031", x => x.IDAmb);
                });

            migrationBuilder.CreateTable(
                name: "Doctor",
                columns: table => new
                {
                    IDDoc = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: false),
                    Especialización = table.Column<string>(type: "varchar(30)", unicode: false, maxLength: 30, nullable: false),
                    Horario_de_atención = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: true),
                    Rut = table.Column<string>(type: "varchar(12)", unicode: false, maxLength: 12, nullable: false),
                    Número_de_casa = table.Column<int>(type: "int", nullable: false),
                    Calle = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: false),
                    Ciudad = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Doctor__93E3A42C009D3353", x => x.IDDoc);
                });

            migrationBuilder.CreateTable(
                name: "Enfermero",
                columns: table => new
                {
                    IDEnf = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: false),
                    Rut = table.Column<string>(type: "varchar(12)", unicode: false, maxLength: 12, nullable: false),
                    Horario_de_atención = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: true),
                    Número_de_casa = table.Column<int>(type: "int", nullable: false),
                    Calle = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: false),
                    Ciudad = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Enfermer__922E7E2B4BDB3F79", x => x.IDEnf);
                });

            migrationBuilder.CreateTable(
                name: "Farmacia",
                columns: table => new
                {
                    IDFar = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Horario_de_atencion = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: true),
                    Ubicacion = table.Column<string>(type: "varchar(30)", unicode: false, maxLength: 30, nullable: false),
                    Capacidad_de_stock = table.Column<int>(type: "int", nullable: true),
                    Lista_de_medicamentos = table.Column<string>(type: "varchar(200)", unicode: false, maxLength: 200, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Farmacia__92680E79A0D2794D", x => x.IDFar);
                });

            migrationBuilder.CreateTable(
                name: "Paramedico",
                columns: table => new
                {
                    IDPar = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: false),
                    Rut = table.Column<string>(type: "varchar(12)", unicode: false, maxLength: 12, nullable: false),
                    Horario_de_atención = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: true),
                    Certificación = table.Column<string>(type: "varchar(30)", unicode: false, maxLength: 30, nullable: false),
                    Número_de_casa = table.Column<int>(type: "int", nullable: false),
                    Calle = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: false),
                    Ciudad = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Paramedi__98F9A64330B511A2", x => x.IDPar);
                });

            migrationBuilder.CreateTable(
                name: "Recepcionista",
                columns: table => new
                {
                    IDRecep = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Rut = table.Column<string>(type: "varchar(12)", unicode: false, maxLength: 12, nullable: true),
                    Departamento_médico = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: true),
                    Horario = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: true),
                    Primer_nombre = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: false),
                    Primer_apellido = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: false),
                    Segundo_apellido = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Recepcio__083226BDFBF65020", x => x.IDRecep);
                });

            migrationBuilder.CreateTable(
                name: "RoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RoleClaims", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Roles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Sala",
                columns: table => new
                {
                    IDSala = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Código = table.Column<string>(type: "varchar(10)", unicode: false, maxLength: 10, nullable: true),
                    Tipo = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: false),
                    Capacidad_de_pacientes = table.Column<int>(type: "int", nullable: false),
                    Nombre_de_paciente = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: false),
                    Fecha = table.Column<DateTime>(type: "date", nullable: true),
                    Hora_de_entrada = table.Column<TimeSpan>(type: "time", nullable: true),
                    Hora_de_salida = table.Column<TimeSpan>(type: "time", nullable: true),
                    Diagnóstico = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: true),
                    Tratamiento = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Sala__C6F3BA0F5BB7B1B5", x => x.IDSala);
                });

            migrationBuilder.CreateTable(
                name: "UserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserClaims", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "UserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProviderKey = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "UserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RoleId = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "UserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LoginProvider = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "EAsisteD",
                columns: table => new
                {
                    IDEnfermero = table.Column<int>(type: "int", nullable: false),
                    IDDoctor = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__EAsisteD__4A82519811755808", x => new { x.IDEnfermero, x.IDDoctor });
                    table.ForeignKey(
                        name: "FK__EAsisteD__IDDoct__797309D9",
                        column: x => x.IDDoctor,
                        principalTable: "Doctor",
                        principalColumn: "IDDoc",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK__EAsisteD__IDEnfe__787EE5A0",
                        column: x => x.IDEnfermero,
                        principalTable: "Enfermero",
                        principalColumn: "IDEnf",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "NúmeroDeTelefonoEnfermero",
                columns: table => new
                {
                    IDNumEnf = table.Column<int>(type: "int", nullable: false),
                    NúmeroDeTelefono = table.Column<string>(type: "varchar(15)", unicode: false, maxLength: 15, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__NúmeroDe__8C423383483E8856", x => x.IDNumEnf);
                    table.ForeignKey(
                        name: "FK__NúmeroDeT__IDNum__4D94879B",
                        column: x => x.IDNumEnf,
                        principalTable: "Enfermero",
                        principalColumn: "IDEnf",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Medicamento",
                columns: table => new
                {
                    IDMed = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Código_en_bodega = table.Column<string>(type: "varchar(10)", unicode: false, maxLength: 10, nullable: true),
                    Nombre = table.Column<string>(type: "varchar(30)", unicode: false, maxLength: 30, nullable: false),
                    Fecha_de_caducidad = table.Column<DateTime>(type: "date", nullable: false),
                    Instrucciones_de_uso = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    Integredientes = table.Column<string>(type: "varchar(400)", unicode: false, maxLength: 400, nullable: false),
                    Fórmula_farmaceutica = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: true),
                    IDFarmacia = table.Column<int>(type: "int", nullable: true),
                    IDDoctor = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Medicame__941E75944685AEBE", x => x.IDMed);
                    table.ForeignKey(
                        name: "FK__Medicamen__IDDoc__02084FDA",
                        column: x => x.IDDoctor,
                        principalTable: "Doctor",
                        principalColumn: "IDDoc",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK__Medicamen__IDFar__01142BA1",
                        column: x => x.IDFarmacia,
                        principalTable: "Farmacia",
                        principalColumn: "IDFar",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "NúmeroDeTelefonoDeFarmacia",
                columns: table => new
                {
                    IDNumFar = table.Column<int>(type: "int", nullable: false),
                    NúmeroDeTelefono = table.Column<string>(type: "varchar(15)", unicode: false, maxLength: 15, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__NúmeroDe__8D039F1C9C33FD94", x => x.IDNumFar);
                    table.ForeignKey(
                        name: "FK__NúmeroDeT__IDNum__59FA5E80",
                        column: x => x.IDNumFar,
                        principalTable: "Farmacia",
                        principalColumn: "IDFar",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Conduce",
                columns: table => new
                {
                    IDParamedico = table.Column<int>(type: "int", nullable: false),
                    IDAmbul = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Conduce__F90D710CCA81BC2B", x => new { x.IDParamedico, x.IDAmbul });
                    table.ForeignKey(
                        name: "FK__Conduce__IDAmbul__66603565",
                        column: x => x.IDAmbul,
                        principalTable: "Ambulancia",
                        principalColumn: "IDAmb",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK__Conduce__IDParam__656C112C",
                        column: x => x.IDParamedico,
                        principalTable: "Paramedico",
                        principalColumn: "IDPar",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "NúmeroTelefonoParamedico",
                columns: table => new
                {
                    IDNumPara = table.Column<int>(type: "int", nullable: false),
                    NúmeroDeTelefono = table.Column<string>(type: "varchar(15)", unicode: false, maxLength: 15, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__NúmeroTe__7F3F0E547756E300", x => x.IDNumPara);
                    table.ForeignKey(
                        name: "FK__NúmeroTel__IDNum__52593CB8",
                        column: x => x.IDNumPara,
                        principalTable: "Paramedico",
                        principalColumn: "IDPar",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "NúmeroDeTelefonoDeRecepcionista",
                columns: table => new
                {
                    IDNumRecep = table.Column<int>(type: "int", nullable: false),
                    NúmeroDeTelefono = table.Column<string>(type: "varchar(15)", unicode: false, maxLength: 15, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__NúmeroDe__64305DC24E30AFCF", x => x.IDNumRecep);
                    table.ForeignKey(
                        name: "FK__NúmeroDeT__IDNum__5FB337D6",
                        column: x => x.IDNumRecep,
                        principalTable: "Recepcionista",
                        principalColumn: "IDRecep",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Paciente",
                columns: table => new
                {
                    IDPac = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Rut = table.Column<string>(type: "varchar(12)", unicode: false, maxLength: 12, nullable: true),
                    Nombre = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: false),
                    Pago = table.Column<int>(type: "int", nullable: false),
                    Problema = table.Column<string>(type: "varchar(30)", unicode: false, maxLength: 30, nullable: false),
                    Historia_clínica = table.Column<string>(type: "varchar(30)", unicode: false, maxLength: 30, nullable: true),
                    Número_de_casa = table.Column<int>(type: "int", nullable: true),
                    Calle = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: true),
                    Ciudad = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: false),
                    SalaID = table.Column<int>(type: "int", nullable: true),
                    IDAmbul = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Paciente__98F9A670F6C82C52", x => x.IDPac);
                    table.ForeignKey(
                        name: "FK__Paciente__IDAmbu__6B24EA82",
                        column: x => x.IDAmbul,
                        principalTable: "Ambulancia",
                        principalColumn: "IDAmb",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK__Paciente__SalaID__6A30C649",
                        column: x => x.SalaID,
                        principalTable: "Sala",
                        principalColumn: "IDSala",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Cita_medica",
                columns: table => new
                {
                    IDCitaMed = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Motivo = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: false),
                    Pago = table.Column<int>(type: "int", nullable: false),
                    Departamento_medico = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: true),
                    Día = table.Column<int>(type: "int", nullable: false),
                    Mes = table.Column<int>(type: "int", nullable: false),
                    Año = table.Column<int>(type: "int", nullable: false),
                    IDPaciente = table.Column<int>(type: "int", nullable: true),
                    IDSal = table.Column<int>(type: "int", nullable: true),
                    IDRecepcionista = table.Column<int>(type: "int", nullable: true),
                    IDDoctor = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Cita_med__7AF11908FCA1623A", x => x.IDCitaMed);
                    table.ForeignKey(
                        name: "FK_four",
                        column: x => x.IDDoctor,
                        principalTable: "Doctor",
                        principalColumn: "IDDoc",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_one",
                        column: x => x.IDPaciente,
                        principalTable: "Paciente",
                        principalColumn: "IDPac",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_three",
                        column: x => x.IDRecepcionista,
                        principalTable: "Recepcionista",
                        principalColumn: "IDRecep",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_two",
                        column: x => x.IDSal,
                        principalTable: "Sala",
                        principalColumn: "IDSala");
                });

            migrationBuilder.CreateTable(
                name: "DAtiendeP",
                columns: table => new
                {
                    IDPaciente = table.Column<int>(type: "int", nullable: false),
                    IDDoctor = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__DAtiende__4E906891042A5FAD", x => new { x.IDPaciente, x.IDDoctor });
                    table.ForeignKey(
                        name: "FK__DAtiendeP__IDDoc__71D1E811",
                        column: x => x.IDDoctor,
                        principalTable: "Doctor",
                        principalColumn: "IDDoc",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK__DAtiendeP__IDPac__70DDC3D8",
                        column: x => x.IDPaciente,
                        principalTable: "Paciente",
                        principalColumn: "IDPac",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "EAtiendeP",
                columns: table => new
                {
                    IDPacient = table.Column<int>(type: "int", nullable: false),
                    IDEnfermero = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__EAtiende__B2F97C0F40F43C3C", x => new { x.IDPacient, x.IDEnfermero });
                    table.ForeignKey(
                        name: "FK__EAtiendeP__IDEnf__75A278F5",
                        column: x => x.IDEnfermero,
                        principalTable: "Enfermero",
                        principalColumn: "IDEnf",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK__EAtiendeP__IDPac__74AE54BC",
                        column: x => x.IDPacient,
                        principalTable: "Paciente",
                        principalColumn: "IDPac",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "NúmeroDeTelefonoDePaciente",
                columns: table => new
                {
                    IDNumPac = table.Column<int>(type: "int", nullable: false),
                    NúmeroDeTelefono = table.Column<string>(type: "varchar(15)", unicode: false, maxLength: 15, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__NúmeroDe__5DCA472A9D5F8180", x => x.IDNumPac);
                    table.ForeignKey(
                        name: "FK__NúmeroDeT__IDNum__6E01572D",
                        column: x => x.IDNumPac,
                        principalTable: "Paciente",
                        principalColumn: "IDPac",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PAtiendeP",
                columns: table => new
                {
                    IDPaciente = table.Column<int>(type: "int", nullable: false),
                    IDParamedico = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__PAtiende__20D292773BC3EE02", x => new { x.IDPaciente, x.IDParamedico });
                    table.ForeignKey(
                        name: "FK__PAtiendeP__IDPac__7C4F7684",
                        column: x => x.IDPaciente,
                        principalTable: "Paciente",
                        principalColumn: "IDPac",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK__PAtiendeP__IDPar__7D439ABD",
                        column: x => x.IDParamedico,
                        principalTable: "Paramedico",
                        principalColumn: "IDPar",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "UQ__Ambulanc__CA6551662B26B919",
                table: "Ambulancia",
                column: "Patente",
                unique: true,
                filter: "[Patente] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Cita_medica_IDDoctor",
                table: "Cita_medica",
                column: "IDDoctor");

            migrationBuilder.CreateIndex(
                name: "IX_Cita_medica_IDPaciente",
                table: "Cita_medica",
                column: "IDPaciente");

            migrationBuilder.CreateIndex(
                name: "IX_Cita_medica_IDRecepcionista",
                table: "Cita_medica",
                column: "IDRecepcionista");

            migrationBuilder.CreateIndex(
                name: "IX_Cita_medica_IDSal",
                table: "Cita_medica",
                column: "IDSal");

            migrationBuilder.CreateIndex(
                name: "IX_Conduce_IDAmbul",
                table: "Conduce",
                column: "IDAmbul");

            migrationBuilder.CreateIndex(
                name: "IX_DAtiendeP_IDDoctor",
                table: "DAtiendeP",
                column: "IDDoctor");

            migrationBuilder.CreateIndex(
                name: "IX_EAsisteD_IDDoctor",
                table: "EAsisteD",
                column: "IDDoctor");

            migrationBuilder.CreateIndex(
                name: "IX_EAtiendeP_IDEnfermero",
                table: "EAtiendeP",
                column: "IDEnfermero");

            migrationBuilder.CreateIndex(
                name: "IX_Medicamento_IDDoctor",
                table: "Medicamento",
                column: "IDDoctor");

            migrationBuilder.CreateIndex(
                name: "IX_Medicamento_IDFarmacia",
                table: "Medicamento",
                column: "IDFarmacia");

            migrationBuilder.CreateIndex(
                name: "UQ__Medicame__7233961EF50DE055",
                table: "Medicamento",
                column: "Código_en_bodega",
                unique: true,
                filter: "[Código_en_bodega] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Paciente_IDAmbul",
                table: "Paciente",
                column: "IDAmbul");

            migrationBuilder.CreateIndex(
                name: "IX_Paciente_SalaID",
                table: "Paciente",
                column: "SalaID");

            migrationBuilder.CreateIndex(
                name: "UQ__Paciente__CAF036600AADE94F",
                table: "Paciente",
                column: "Rut",
                unique: true,
                filter: "[Rut] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_PAtiendeP_IDParamedico",
                table: "PAtiendeP",
                column: "IDParamedico");

            migrationBuilder.CreateIndex(
                name: "UQ__Recepcio__CAF0366042E580CF",
                table: "Recepcionista",
                column: "Rut",
                unique: true,
                filter: "[Rut] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "UQ__Sala__D68C8CB051C52F91",
                table: "Sala",
                column: "Código",
                unique: true,
                filter: "[Código] IS NOT NULL");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Cita_medica");

            migrationBuilder.DropTable(
                name: "Conduce");

            migrationBuilder.DropTable(
                name: "DAtiendeP");

            migrationBuilder.DropTable(
                name: "EAsisteD");

            migrationBuilder.DropTable(
                name: "EAtiendeP");

            migrationBuilder.DropTable(
                name: "Medicamento");

            migrationBuilder.DropTable(
                name: "NúmeroDeTelefonoDeFarmacia");

            migrationBuilder.DropTable(
                name: "NúmeroDeTelefonoDePaciente");

            migrationBuilder.DropTable(
                name: "NúmeroDeTelefonoDeRecepcionista");

            migrationBuilder.DropTable(
                name: "NúmeroDeTelefonoEnfermero");

            migrationBuilder.DropTable(
                name: "NúmeroTelefonoParamedico");

            migrationBuilder.DropTable(
                name: "PAtiendeP");

            migrationBuilder.DropTable(
                name: "RoleClaims");

            migrationBuilder.DropTable(
                name: "Roles");

            migrationBuilder.DropTable(
                name: "UserClaims");

            migrationBuilder.DropTable(
                name: "UserLogins");

            migrationBuilder.DropTable(
                name: "UserRoles");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "UserTokens");

            migrationBuilder.DropTable(
                name: "Doctor");

            migrationBuilder.DropTable(
                name: "Farmacia");

            migrationBuilder.DropTable(
                name: "Recepcionista");

            migrationBuilder.DropTable(
                name: "Enfermero");

            migrationBuilder.DropTable(
                name: "Paciente");

            migrationBuilder.DropTable(
                name: "Paramedico");

            migrationBuilder.DropTable(
                name: "Ambulancia");

            migrationBuilder.DropTable(
                name: "Sala");
        }
    }
}

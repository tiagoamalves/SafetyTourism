using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SafetyTourism.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DestinoTuristicos",
                columns: table => new
                {
                    DestinoTuristicoID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NomeDestino = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DensidadeDemografica = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Pais = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Continente = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DestinoTuristicos", x => x.DestinoTuristicoID);
                });

            migrationBuilder.CreateTable(
                name: "Doencas",
                columns: table => new
                {
                    DoencaID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NomeDoenca = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Doencas", x => x.DoencaID);
                });

            migrationBuilder.CreateTable(
                name: "Funcionarios",
                columns: table => new
                {
                    FuncionarioID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NomeFuncionario = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MailFuncionario = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Funcionarios", x => x.FuncionarioID);
                });

            migrationBuilder.CreateTable(
                name: "GravidadeSurtos",
                columns: table => new
                {
                    GravidadeSurtoID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DataRegisto = table.Column<DateTime>(type: "datetime2", nullable: false),
                    NivelGravidade = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GravidadeSurtos", x => x.GravidadeSurtoID);
                });

            migrationBuilder.CreateTable(
                name: "Recomendacoes",
                columns: table => new
                {
                    RecomendacoeID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DataRegisto = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DescricaoBreve = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Relatorio = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Recomendacoes", x => x.RecomendacoeID);
                });

            migrationBuilder.CreateTable(
                name: "Sintomas",
                columns: table => new
                {
                    SintomaID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DataRegisto = table.Column<DateTime>(type: "datetime2", nullable: false),
                    NomeSintoma = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sintomas", x => x.SintomaID);
                });

            migrationBuilder.CreateTable(
                name: "Utilizadors",
                columns: table => new
                {
                    UtilizadorID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NomeUtilizador = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MoradaUtilizador = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MailUtilizador = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Utilizadors", x => x.UtilizadorID);
                });

            migrationBuilder.CreateTable(
                name: "GrupoRiscos",
                columns: table => new
                {
                    GrupoRiscoID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FaixaEtaria = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Sexo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Etnia = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DoencaID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GrupoRiscos", x => x.GrupoRiscoID);
                    table.ForeignKey(
                        name: "FK_GrupoRiscos_Doencas_DoencaID",
                        column: x => x.DoencaID,
                        principalTable: "Doencas",
                        principalColumn: "DoencaID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SurtosEpidemiologicos",
                columns: table => new
                {
                    SurtosEpidemiologicoID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NomeSurto = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GrauContagio = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IndiceMortalidade = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GravidadeSurtoID = table.Column<int>(type: "int", nullable: false),
                    RecomendacoeID = table.Column<int>(type: "int", nullable: false),
                    SintomaID = table.Column<int>(type: "int", nullable: false),
                    GrupoRiscoID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SurtosEpidemiologicos", x => x.SurtosEpidemiologicoID);
                    table.ForeignKey(
                        name: "FK_SurtosEpidemiologicos_GravidadeSurtos_GravidadeSurtoID",
                        column: x => x.GravidadeSurtoID,
                        principalTable: "GravidadeSurtos",
                        principalColumn: "GravidadeSurtoID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SurtosEpidemiologicos_GrupoRiscos_GrupoRiscoID",
                        column: x => x.GrupoRiscoID,
                        principalTable: "GrupoRiscos",
                        principalColumn: "GrupoRiscoID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SurtosEpidemiologicos_Recomendacoes_RecomendacoeID",
                        column: x => x.RecomendacoeID,
                        principalTable: "Recomendacoes",
                        principalColumn: "RecomendacoeID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SurtosEpidemiologicos_Sintomas_SintomaID",
                        column: x => x.SintomaID,
                        principalTable: "Sintomas",
                        principalColumn: "SintomaID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SurtosOcurrencias",
                columns: table => new
                {
                    SurtosOcurrenciaID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DataInicio = table.Column<DateTime>(type: "datetime2", nullable: false),
                    SurtosEpidemiologicoID = table.Column<int>(type: "int", nullable: false),
                    DestinoTuristicoID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SurtosOcurrencias", x => x.SurtosOcurrenciaID);
                    table.ForeignKey(
                        name: "FK_SurtosOcurrencias_DestinoTuristicos_DestinoTuristicoID",
                        column: x => x.DestinoTuristicoID,
                        principalTable: "DestinoTuristicos",
                        principalColumn: "DestinoTuristicoID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SurtosOcurrencias_SurtosEpidemiologicos_SurtosEpidemiologicoID",
                        column: x => x.SurtosEpidemiologicoID,
                        principalTable: "SurtosEpidemiologicos",
                        principalColumn: "SurtosEpidemiologicoID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_GrupoRiscos_DoencaID",
                table: "GrupoRiscos",
                column: "DoencaID");

            migrationBuilder.CreateIndex(
                name: "IX_SurtosEpidemiologicos_GravidadeSurtoID",
                table: "SurtosEpidemiologicos",
                column: "GravidadeSurtoID");

            migrationBuilder.CreateIndex(
                name: "IX_SurtosEpidemiologicos_GrupoRiscoID",
                table: "SurtosEpidemiologicos",
                column: "GrupoRiscoID");

            migrationBuilder.CreateIndex(
                name: "IX_SurtosEpidemiologicos_RecomendacoeID",
                table: "SurtosEpidemiologicos",
                column: "RecomendacoeID");

            migrationBuilder.CreateIndex(
                name: "IX_SurtosEpidemiologicos_SintomaID",
                table: "SurtosEpidemiologicos",
                column: "SintomaID");

            migrationBuilder.CreateIndex(
                name: "IX_SurtosOcurrencias_DestinoTuristicoID",
                table: "SurtosOcurrencias",
                column: "DestinoTuristicoID");

            migrationBuilder.CreateIndex(
                name: "IX_SurtosOcurrencias_SurtosEpidemiologicoID",
                table: "SurtosOcurrencias",
                column: "SurtosEpidemiologicoID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Funcionarios");

            migrationBuilder.DropTable(
                name: "SurtosOcurrencias");

            migrationBuilder.DropTable(
                name: "Utilizadors");

            migrationBuilder.DropTable(
                name: "DestinoTuristicos");

            migrationBuilder.DropTable(
                name: "SurtosEpidemiologicos");

            migrationBuilder.DropTable(
                name: "GravidadeSurtos");

            migrationBuilder.DropTable(
                name: "GrupoRiscos");

            migrationBuilder.DropTable(
                name: "Recomendacoes");

            migrationBuilder.DropTable(
                name: "Sintomas");

            migrationBuilder.DropTable(
                name: "Doencas");
        }
    }
}

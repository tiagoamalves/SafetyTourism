using Microsoft.EntityFrameworkCore.Migrations;

namespace SafetyTourismPaulo.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Doencas_GrupoRiscos_GrupoRiscoID",
                table: "Doencas");

            migrationBuilder.DropForeignKey(
                name: "FK_GravidadeSurtos_SurtosEpidemiologico_SurtosEpidemiologicoID",
                table: "GravidadeSurtos");

            migrationBuilder.DropForeignKey(
                name: "FK_GrupoRiscos_SurtosEpidemiologico_SurtosEpidemiologicoID",
                table: "GrupoRiscos");

            migrationBuilder.DropForeignKey(
                name: "FK_Recomendacoes_SurtosEpidemiologico_SurtosEpidemiologicoID",
                table: "Recomendacoes");

            migrationBuilder.DropForeignKey(
                name: "FK_Sintomas_SurtosEpidemiologico_SurtosEpidemiologicoID",
                table: "Sintomas");

            migrationBuilder.DropIndex(
                name: "IX_SurtosOcurrencias_SurtosEpidemiologicoID",
                table: "SurtosOcurrencias");

            migrationBuilder.DropIndex(
                name: "IX_Sintomas_SurtosEpidemiologicoID",
                table: "Sintomas");

            migrationBuilder.DropIndex(
                name: "IX_Recomendacoes_SurtosEpidemiologicoID",
                table: "Recomendacoes");

            migrationBuilder.DropIndex(
                name: "IX_GrupoRiscos_SurtosEpidemiologicoID",
                table: "GrupoRiscos");

            migrationBuilder.DropIndex(
                name: "IX_GravidadeSurtos_SurtosEpidemiologicoID",
                table: "GravidadeSurtos");

            migrationBuilder.DropIndex(
                name: "IX_Doencas_GrupoRiscoID",
                table: "Doencas");

            migrationBuilder.DropColumn(
                name: "SurtosEpidemiologicoID",
                table: "Sintomas");

            migrationBuilder.DropColumn(
                name: "SurtosEpidemiologicoID",
                table: "Recomendacoes");

            migrationBuilder.DropColumn(
                name: "SurtosEpidemiologicoID",
                table: "GrupoRiscos");

            migrationBuilder.DropColumn(
                name: "SurtosEpidemiologicoID",
                table: "GravidadeSurtos");

            migrationBuilder.DropColumn(
                name: "GrupoRiscoID",
                table: "Doencas");

            migrationBuilder.DropColumn(
                name: "SurtosOcurrenciaID",
                table: "DestinoTuristico");

            migrationBuilder.CreateIndex(
                name: "IX_SurtosOcurrencias_SurtosEpidemiologicoID",
                table: "SurtosOcurrencias",
                column: "SurtosEpidemiologicoID");

            migrationBuilder.CreateIndex(
                name: "IX_SurtosEpidemiologico_GravidadeSurtoID",
                table: "SurtosEpidemiologico",
                column: "GravidadeSurtoID");

            migrationBuilder.CreateIndex(
                name: "IX_SurtosEpidemiologico_GrupoRiscoID",
                table: "SurtosEpidemiologico",
                column: "GrupoRiscoID");

            migrationBuilder.CreateIndex(
                name: "IX_SurtosEpidemiologico_RecomendacoeID",
                table: "SurtosEpidemiologico",
                column: "RecomendacoeID");

            migrationBuilder.CreateIndex(
                name: "IX_SurtosEpidemiologico_SintomaID",
                table: "SurtosEpidemiologico",
                column: "SintomaID");

            migrationBuilder.CreateIndex(
                name: "IX_GrupoRiscos_DoencaID",
                table: "GrupoRiscos",
                column: "DoencaID");

            migrationBuilder.AddForeignKey(
                name: "FK_GrupoRiscos_Doencas_DoencaID",
                table: "GrupoRiscos",
                column: "DoencaID",
                principalTable: "Doencas",
                principalColumn: "DoencaID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SurtosEpidemiologico_GravidadeSurtos_GravidadeSurtoID",
                table: "SurtosEpidemiologico",
                column: "GravidadeSurtoID",
                principalTable: "GravidadeSurtos",
                principalColumn: "GravidadeSurtoID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SurtosEpidemiologico_GrupoRiscos_GrupoRiscoID",
                table: "SurtosEpidemiologico",
                column: "GrupoRiscoID",
                principalTable: "GrupoRiscos",
                principalColumn: "GrupoRiscoID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SurtosEpidemiologico_Recomendacoes_RecomendacoeID",
                table: "SurtosEpidemiologico",
                column: "RecomendacoeID",
                principalTable: "Recomendacoes",
                principalColumn: "RecomendacoeID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SurtosEpidemiologico_Sintomas_SintomaID",
                table: "SurtosEpidemiologico",
                column: "SintomaID",
                principalTable: "Sintomas",
                principalColumn: "SintomaID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_GrupoRiscos_Doencas_DoencaID",
                table: "GrupoRiscos");

            migrationBuilder.DropForeignKey(
                name: "FK_SurtosEpidemiologico_GravidadeSurtos_GravidadeSurtoID",
                table: "SurtosEpidemiologico");

            migrationBuilder.DropForeignKey(
                name: "FK_SurtosEpidemiologico_GrupoRiscos_GrupoRiscoID",
                table: "SurtosEpidemiologico");

            migrationBuilder.DropForeignKey(
                name: "FK_SurtosEpidemiologico_Recomendacoes_RecomendacoeID",
                table: "SurtosEpidemiologico");

            migrationBuilder.DropForeignKey(
                name: "FK_SurtosEpidemiologico_Sintomas_SintomaID",
                table: "SurtosEpidemiologico");

            migrationBuilder.DropIndex(
                name: "IX_SurtosOcurrencias_SurtosEpidemiologicoID",
                table: "SurtosOcurrencias");

            migrationBuilder.DropIndex(
                name: "IX_SurtosEpidemiologico_GravidadeSurtoID",
                table: "SurtosEpidemiologico");

            migrationBuilder.DropIndex(
                name: "IX_SurtosEpidemiologico_GrupoRiscoID",
                table: "SurtosEpidemiologico");

            migrationBuilder.DropIndex(
                name: "IX_SurtosEpidemiologico_RecomendacoeID",
                table: "SurtosEpidemiologico");

            migrationBuilder.DropIndex(
                name: "IX_SurtosEpidemiologico_SintomaID",
                table: "SurtosEpidemiologico");

            migrationBuilder.DropIndex(
                name: "IX_GrupoRiscos_DoencaID",
                table: "GrupoRiscos");

            migrationBuilder.AddColumn<int>(
                name: "SurtosEpidemiologicoID",
                table: "Sintomas",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "SurtosEpidemiologicoID",
                table: "Recomendacoes",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "SurtosEpidemiologicoID",
                table: "GrupoRiscos",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "SurtosEpidemiologicoID",
                table: "GravidadeSurtos",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "GrupoRiscoID",
                table: "Doencas",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "SurtosOcurrenciaID",
                table: "DestinoTuristico",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_SurtosOcurrencias_SurtosEpidemiologicoID",
                table: "SurtosOcurrencias",
                column: "SurtosEpidemiologicoID",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Sintomas_SurtosEpidemiologicoID",
                table: "Sintomas",
                column: "SurtosEpidemiologicoID");

            migrationBuilder.CreateIndex(
                name: "IX_Recomendacoes_SurtosEpidemiologicoID",
                table: "Recomendacoes",
                column: "SurtosEpidemiologicoID");

            migrationBuilder.CreateIndex(
                name: "IX_GrupoRiscos_SurtosEpidemiologicoID",
                table: "GrupoRiscos",
                column: "SurtosEpidemiologicoID");

            migrationBuilder.CreateIndex(
                name: "IX_GravidadeSurtos_SurtosEpidemiologicoID",
                table: "GravidadeSurtos",
                column: "SurtosEpidemiologicoID");

            migrationBuilder.CreateIndex(
                name: "IX_Doencas_GrupoRiscoID",
                table: "Doencas",
                column: "GrupoRiscoID");

            migrationBuilder.AddForeignKey(
                name: "FK_Doencas_GrupoRiscos_GrupoRiscoID",
                table: "Doencas",
                column: "GrupoRiscoID",
                principalTable: "GrupoRiscos",
                principalColumn: "GrupoRiscoID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_GravidadeSurtos_SurtosEpidemiologico_SurtosEpidemiologicoID",
                table: "GravidadeSurtos",
                column: "SurtosEpidemiologicoID",
                principalTable: "SurtosEpidemiologico",
                principalColumn: "SurtosEpidemiologicoID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_GrupoRiscos_SurtosEpidemiologico_SurtosEpidemiologicoID",
                table: "GrupoRiscos",
                column: "SurtosEpidemiologicoID",
                principalTable: "SurtosEpidemiologico",
                principalColumn: "SurtosEpidemiologicoID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Recomendacoes_SurtosEpidemiologico_SurtosEpidemiologicoID",
                table: "Recomendacoes",
                column: "SurtosEpidemiologicoID",
                principalTable: "SurtosEpidemiologico",
                principalColumn: "SurtosEpidemiologicoID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Sintomas_SurtosEpidemiologico_SurtosEpidemiologicoID",
                table: "Sintomas",
                column: "SurtosEpidemiologicoID",
                principalTable: "SurtosEpidemiologico",
                principalColumn: "SurtosEpidemiologicoID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}

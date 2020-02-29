using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SistemaGestaoClinicaMedica.Infra.Data.Migrations
{
    public partial class Init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Cargo",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Nome = table.Column<string>(maxLength: 500, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cargo", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Especialidade",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Nome = table.Column<string>(maxLength: 500, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Especialidade", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Funcionario",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Nome = table.Column<string>(maxLength: 500, nullable: false),
                    Email = table.Column<string>(maxLength: 200, nullable: false),
                    Telefone = table.Column<string>(maxLength: 100, nullable: true),
                    Senha = table.Column<string>(maxLength: 100, nullable: false),
                    CargoId = table.Column<string>(nullable: true),
                    Ativo = table.Column<bool>(nullable: false, defaultValue: true),
                    CriadoEm = table.Column<DateTime>(nullable: false, defaultValue: new DateTime(2020, 2, 29, 1, 12, 53, 403, DateTimeKind.Local).AddTicks(161))
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Funcionario", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Funcionario_Cargo_CargoId",
                        column: x => x.CargoId,
                        principalTable: "Cargo",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Administrador",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    FuncionarioId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Administrador", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Administrador_Funcionario_FuncionarioId",
                        column: x => x.FuncionarioId,
                        principalTable: "Funcionario",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Laboratorio",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    FuncionarioId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Laboratorio", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Laboratorio_Funcionario_FuncionarioId",
                        column: x => x.FuncionarioId,
                        principalTable: "Funcionario",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Medico",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CRM = table.Column<string>(maxLength: 50, nullable: false),
                    FuncionarioId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Medico", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Medico_Funcionario_FuncionarioId",
                        column: x => x.FuncionarioId,
                        principalTable: "Funcionario",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Recepcionista",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    FuncionarioId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Recepcionista", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Recepcionista_Funcionario_FuncionarioId",
                        column: x => x.FuncionarioId,
                        principalTable: "Funcionario",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "HorarioDeTrabalho",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    DiaDaSemana = table.Column<int>(nullable: false),
                    Inicio = table.Column<TimeSpan>(nullable: false),
                    InicioAlmoco = table.Column<TimeSpan>(nullable: true),
                    FimAlmoco = table.Column<TimeSpan>(nullable: true),
                    Fim = table.Column<TimeSpan>(nullable: false),
                    MedicoId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HorarioDeTrabalho", x => x.Id);
                    table.ForeignKey(
                        name: "FK_HorarioDeTrabalho_Medico_MedicoId",
                        column: x => x.MedicoId,
                        principalTable: "Medico",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "MedicoEspecialidade",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    MedicoId = table.Column<Guid>(nullable: false),
                    EspecialidadeId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MedicoEspecialidade", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MedicoEspecialidade_Medico_EspecialidadeId",
                        column: x => x.EspecialidadeId,
                        principalTable: "Medico",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MedicoEspecialidade_Especialidade_MedicoId",
                        column: x => x.MedicoId,
                        principalTable: "Especialidade",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Cargo",
                columns: new[] { "Id", "Nome" },
                values: new object[] { "Administrador", "Administrador" });

            migrationBuilder.InsertData(
                table: "Cargo",
                columns: new[] { "Id", "Nome" },
                values: new object[] { "Medico", "Médico" });

            migrationBuilder.InsertData(
                table: "Cargo",
                columns: new[] { "Id", "Nome" },
                values: new object[] { "Recepcionista", "Recepcionista" });

            migrationBuilder.InsertData(
                table: "Cargo",
                columns: new[] { "Id", "Nome" },
                values: new object[] { "Laboratorio", "Laboratório" });

            migrationBuilder.InsertData(
                table: "Especialidade",
                columns: new[] { "Id", "Nome" },
                values: new object[] { new Guid("5c66a70c-0977-4117-a4e3-24a1d258fea5"), "Cancerologia" });

            migrationBuilder.InsertData(
                table: "Especialidade",
                columns: new[] { "Id", "Nome" },
                values: new object[] { new Guid("343ab7dc-2ec0-41e6-b332-fa6b0d61e51b"), "Urologia" });

            migrationBuilder.InsertData(
                table: "Especialidade",
                columns: new[] { "Id", "Nome" },
                values: new object[] { new Guid("9c95aece-c4a7-4444-9c1b-0ccd22a5a422"), "Cirurgia Vascular" });

            migrationBuilder.InsertData(
                table: "Especialidade",
                columns: new[] { "Id", "Nome" },
                values: new object[] { new Guid("8b4184e9-1615-47ad-bf48-fea9ccd141da"), "Infectologia" });

            migrationBuilder.InsertData(
                table: "Especialidade",
                columns: new[] { "Id", "Nome" },
                values: new object[] { new Guid("37a176d0-e8a1-4985-857f-bcff3de0d0d1"), "Cirurgia Plástica" });

            migrationBuilder.InsertData(
                table: "Especialidade",
                columns: new[] { "Id", "Nome" },
                values: new object[] { new Guid("35c83d9c-4dd5-40d4-a0e7-172b5f5c81e3"), "Endocrinologia e Metabologia" });

            migrationBuilder.InsertData(
                table: "Especialidade",
                columns: new[] { "Id", "Nome" },
                values: new object[] { new Guid("c140277b-4a84-4bd1-9ecc-50d9184879e4"), "Medicina de Família e Comunidade" });

            migrationBuilder.InsertData(
                table: "Especialidade",
                columns: new[] { "Id", "Nome" },
                values: new object[] { new Guid("b633bb60-d194-4f76-ab91-c01da6e10145"), "Otorrinolaringologia" });

            migrationBuilder.InsertData(
                table: "Especialidade",
                columns: new[] { "Id", "Nome" },
                values: new object[] { new Guid("e929046a-55d9-41eb-a5c5-76c753557767"), "Dermatologia" });

            migrationBuilder.InsertData(
                table: "Especialidade",
                columns: new[] { "Id", "Nome" },
                values: new object[] { new Guid("d3662bee-ca6c-475e-b1ef-949fa795c5c9"), "Radiologia e Diagnóstico por Imagem" });

            migrationBuilder.InsertData(
                table: "Especialidade",
                columns: new[] { "Id", "Nome" },
                values: new object[] { new Guid("04c3ae7d-ad74-44ca-ab79-9c5c2790a7ea"), "Nefrologia" });

            migrationBuilder.InsertData(
                table: "Especialidade",
                columns: new[] { "Id", "Nome" },
                values: new object[] { new Guid("7f8f18e0-b970-4943-92ce-07e3e03dc715"), "Cardiologia" });

            migrationBuilder.InsertData(
                table: "Especialidade",
                columns: new[] { "Id", "Nome" },
                values: new object[] { new Guid("38b22d9b-9829-4ab9-adf3-0aef7168fea7"), "Oftalmologia" });

            migrationBuilder.InsertData(
                table: "Especialidade",
                columns: new[] { "Id", "Nome" },
                values: new object[] { new Guid("c0e064b6-aca9-420f-a90c-73a2e0c684c6"), "Ortopedia e Traumatologia" });

            migrationBuilder.InsertData(
                table: "Especialidade",
                columns: new[] { "Id", "Nome" },
                values: new object[] { new Guid("d37de9e5-2688-4d13-a08d-376a19f54a9e"), "Anestesiologia" });

            migrationBuilder.InsertData(
                table: "Especialidade",
                columns: new[] { "Id", "Nome" },
                values: new object[] { new Guid("c8becf9e-c068-47a1-937f-caa0c30f1a18"), "Ginecologia e Obstetrícia" });

            migrationBuilder.InsertData(
                table: "Especialidade",
                columns: new[] { "Id", "Nome" },
                values: new object[] { new Guid("10dd8bb8-66c8-406b-b5e5-ee4cbd8bff54"), "Pediatria" });

            migrationBuilder.InsertData(
                table: "Especialidade",
                columns: new[] { "Id", "Nome" },
                values: new object[] { new Guid("1fce2684-7655-4792-b97c-f0eccf906186"), "Cirurgia Geral" });

            migrationBuilder.InsertData(
                table: "Especialidade",
                columns: new[] { "Id", "Nome" },
                values: new object[] { new Guid("bc2175bb-ddb0-4adb-ab10-d833fe4dd3e3"), "Clínica Médica" });

            migrationBuilder.InsertData(
                table: "Especialidade",
                columns: new[] { "Id", "Nome" },
                values: new object[] { new Guid("bbdb70af-606e-464b-8374-eb1eb0fd7ed5"), "Psiquiatria" });

            migrationBuilder.InsertData(
                table: "Especialidade",
                columns: new[] { "Id", "Nome" },
                values: new object[] { new Guid("a2a7c7d3-982d-4880-8f39-bd4739744e53"), "Nutrologia" });

            migrationBuilder.CreateIndex(
                name: "IX_Administrador_FuncionarioId",
                table: "Administrador",
                column: "FuncionarioId");

            migrationBuilder.CreateIndex(
                name: "IX_Cargo_Id_Nome",
                table: "Cargo",
                columns: new[] { "Id", "Nome" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Especialidade_Id_Nome",
                table: "Especialidade",
                columns: new[] { "Id", "Nome" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Funcionario_CargoId",
                table: "Funcionario",
                column: "CargoId");

            migrationBuilder.CreateIndex(
                name: "IX_Funcionario_Email",
                table: "Funcionario",
                column: "Email",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_HorarioDeTrabalho_MedicoId",
                table: "HorarioDeTrabalho",
                column: "MedicoId");

            migrationBuilder.CreateIndex(
                name: "IX_Laboratorio_FuncionarioId",
                table: "Laboratorio",
                column: "FuncionarioId");

            migrationBuilder.CreateIndex(
                name: "IX_Medico_CRM",
                table: "Medico",
                column: "CRM",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Medico_FuncionarioId",
                table: "Medico",
                column: "FuncionarioId");

            migrationBuilder.CreateIndex(
                name: "IX_MedicoEspecialidade_EspecialidadeId",
                table: "MedicoEspecialidade",
                column: "EspecialidadeId");

            migrationBuilder.CreateIndex(
                name: "IX_MedicoEspecialidade_MedicoId",
                table: "MedicoEspecialidade",
                column: "MedicoId");

            migrationBuilder.CreateIndex(
                name: "IX_Recepcionista_FuncionarioId",
                table: "Recepcionista",
                column: "FuncionarioId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Administrador");

            migrationBuilder.DropTable(
                name: "HorarioDeTrabalho");

            migrationBuilder.DropTable(
                name: "Laboratorio");

            migrationBuilder.DropTable(
                name: "MedicoEspecialidade");

            migrationBuilder.DropTable(
                name: "Recepcionista");

            migrationBuilder.DropTable(
                name: "Medico");

            migrationBuilder.DropTable(
                name: "Especialidade");

            migrationBuilder.DropTable(
                name: "Funcionario");

            migrationBuilder.DropTable(
                name: "Cargo");
        }
    }
}

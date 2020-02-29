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
                    CriadoEm = table.Column<DateTime>(nullable: false, defaultValue: new DateTime(2020, 2, 29, 13, 5, 40, 980, DateTimeKind.Local).AddTicks(9599))
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
                        name: "FK_MedicoEspecialidade_Especialidade_EspecialidadeId",
                        column: x => x.EspecialidadeId,
                        principalTable: "Especialidade",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MedicoEspecialidade_Medico_MedicoId",
                        column: x => x.MedicoId,
                        principalTable: "Medico",
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
                values: new object[] { new Guid("a852a1ed-7c4a-4e52-87ca-0acb3c1de0f0"), "Cancerologia" });

            migrationBuilder.InsertData(
                table: "Especialidade",
                columns: new[] { "Id", "Nome" },
                values: new object[] { new Guid("62b562bf-29ae-4755-903f-2f8f040d575a"), "Urologia" });

            migrationBuilder.InsertData(
                table: "Especialidade",
                columns: new[] { "Id", "Nome" },
                values: new object[] { new Guid("a87a00fa-89ba-41fa-b4e2-1d3a504c362c"), "Cirurgia Vascular" });

            migrationBuilder.InsertData(
                table: "Especialidade",
                columns: new[] { "Id", "Nome" },
                values: new object[] { new Guid("453ae4e7-1995-4423-ada1-ace0c77353d9"), "Infectologia" });

            migrationBuilder.InsertData(
                table: "Especialidade",
                columns: new[] { "Id", "Nome" },
                values: new object[] { new Guid("7849ad8f-f695-4c3e-8b8c-2a1b2460f52a"), "Cirurgia Plástica" });

            migrationBuilder.InsertData(
                table: "Especialidade",
                columns: new[] { "Id", "Nome" },
                values: new object[] { new Guid("15aff430-aed9-484a-b455-1490aca10b42"), "Endocrinologia e Metabologia" });

            migrationBuilder.InsertData(
                table: "Especialidade",
                columns: new[] { "Id", "Nome" },
                values: new object[] { new Guid("52bbbef5-306b-4165-a147-5190a019950c"), "Medicina de Família e Comunidade" });

            migrationBuilder.InsertData(
                table: "Especialidade",
                columns: new[] { "Id", "Nome" },
                values: new object[] { new Guid("ee0229f2-0a5b-4b47-8c6c-9cd32344f62b"), "Otorrinolaringologia" });

            migrationBuilder.InsertData(
                table: "Especialidade",
                columns: new[] { "Id", "Nome" },
                values: new object[] { new Guid("7c48680d-86a0-403f-a8c8-99a90dcf6e97"), "Dermatologia" });

            migrationBuilder.InsertData(
                table: "Especialidade",
                columns: new[] { "Id", "Nome" },
                values: new object[] { new Guid("958c7eaa-5985-4e45-8915-53f54273a899"), "Radiologia e Diagnóstico por Imagem" });

            migrationBuilder.InsertData(
                table: "Especialidade",
                columns: new[] { "Id", "Nome" },
                values: new object[] { new Guid("67340135-df5b-4eee-9942-917f9176bcac"), "Nefrologia" });

            migrationBuilder.InsertData(
                table: "Especialidade",
                columns: new[] { "Id", "Nome" },
                values: new object[] { new Guid("56ebc620-2aa3-48f0-a5e8-7d6b9b1447b4"), "Cardiologia" });

            migrationBuilder.InsertData(
                table: "Especialidade",
                columns: new[] { "Id", "Nome" },
                values: new object[] { new Guid("e8bbb4d2-8974-4fb0-b526-0d74af3be217"), "Oftalmologia" });

            migrationBuilder.InsertData(
                table: "Especialidade",
                columns: new[] { "Id", "Nome" },
                values: new object[] { new Guid("26dec9b3-03a0-49c4-b0c2-b47ca4b662fc"), "Ortopedia e Traumatologia" });

            migrationBuilder.InsertData(
                table: "Especialidade",
                columns: new[] { "Id", "Nome" },
                values: new object[] { new Guid("ae28a7d7-96de-44ef-a79c-581486474d55"), "Anestesiologia" });

            migrationBuilder.InsertData(
                table: "Especialidade",
                columns: new[] { "Id", "Nome" },
                values: new object[] { new Guid("a65be58d-ea82-4a33-b0c3-7f12ca35aa65"), "Ginecologia e Obstetrícia" });

            migrationBuilder.InsertData(
                table: "Especialidade",
                columns: new[] { "Id", "Nome" },
                values: new object[] { new Guid("0ab92166-2992-4f4e-b0a8-8a2df7c48016"), "Pediatria" });

            migrationBuilder.InsertData(
                table: "Especialidade",
                columns: new[] { "Id", "Nome" },
                values: new object[] { new Guid("2a52d623-2296-493e-8e9f-d0cd69781f47"), "Cirurgia Geral" });

            migrationBuilder.InsertData(
                table: "Especialidade",
                columns: new[] { "Id", "Nome" },
                values: new object[] { new Guid("7dfed23b-9a30-401b-8b3b-8c93718b8429"), "Clínica Médica" });

            migrationBuilder.InsertData(
                table: "Especialidade",
                columns: new[] { "Id", "Nome" },
                values: new object[] { new Guid("4394c11a-d312-4a66-b723-ca2af507d66c"), "Psiquiatria" });

            migrationBuilder.InsertData(
                table: "Especialidade",
                columns: new[] { "Id", "Nome" },
                values: new object[] { new Guid("6fdeef11-6736-4163-81dc-1f97f1d59098"), "Nutrologia" });

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
                name: "Especialidade");

            migrationBuilder.DropTable(
                name: "Medico");

            migrationBuilder.DropTable(
                name: "Funcionario");

            migrationBuilder.DropTable(
                name: "Cargo");
        }
    }
}

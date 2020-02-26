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
                    CriadoEm = table.Column<DateTime>(nullable: false, defaultValue: new DateTime(2020, 2, 26, 20, 5, 29, 44, DateTimeKind.Local).AddTicks(9781))
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
                table: "Especialidade",
                columns: new[] { "Id", "Nome" },
                values: new object[] { new Guid("28f2d3ec-5861-4187-9c4f-f8274a7ef3ad"), "Cancerologia" });

            migrationBuilder.InsertData(
                table: "Especialidade",
                columns: new[] { "Id", "Nome" },
                values: new object[] { new Guid("0066630b-0eb4-4ab5-904b-e5b69f488a85"), "Urologia" });

            migrationBuilder.InsertData(
                table: "Especialidade",
                columns: new[] { "Id", "Nome" },
                values: new object[] { new Guid("62019e3e-79a5-4259-9112-5f2d5086ec88"), "Cirurgia Vascular" });

            migrationBuilder.InsertData(
                table: "Especialidade",
                columns: new[] { "Id", "Nome" },
                values: new object[] { new Guid("d703b963-26a1-49c9-94f9-ad6a012467da"), "Infectologia" });

            migrationBuilder.InsertData(
                table: "Especialidade",
                columns: new[] { "Id", "Nome" },
                values: new object[] { new Guid("08f57da9-affa-4ccb-b0e5-633a6c236fc8"), "Cirurgia Plástica" });

            migrationBuilder.InsertData(
                table: "Especialidade",
                columns: new[] { "Id", "Nome" },
                values: new object[] { new Guid("f39a3b16-d41a-41ea-84f8-441dd62ec56c"), "Endocrinologia e Metabologia" });

            migrationBuilder.InsertData(
                table: "Especialidade",
                columns: new[] { "Id", "Nome" },
                values: new object[] { new Guid("cd9a9701-6c14-42e4-bd7f-87b76a346164"), "Medicina de Família e Comunidade" });

            migrationBuilder.InsertData(
                table: "Especialidade",
                columns: new[] { "Id", "Nome" },
                values: new object[] { new Guid("9ea67d42-d8fc-484e-86e2-1825d8e86433"), "Otorrinolaringologia" });

            migrationBuilder.InsertData(
                table: "Especialidade",
                columns: new[] { "Id", "Nome" },
                values: new object[] { new Guid("7b655c55-4437-459d-8e70-25dd5d4ecc5e"), "Dermatologia" });

            migrationBuilder.InsertData(
                table: "Especialidade",
                columns: new[] { "Id", "Nome" },
                values: new object[] { new Guid("2ac10d49-656d-4d1f-adf7-823f2854e38a"), "Radiologia e Diagnóstico por Imagem" });

            migrationBuilder.InsertData(
                table: "Especialidade",
                columns: new[] { "Id", "Nome" },
                values: new object[] { new Guid("5418daa5-ea59-4016-863d-68ecf360c656"), "Nefrologia" });

            migrationBuilder.InsertData(
                table: "Especialidade",
                columns: new[] { "Id", "Nome" },
                values: new object[] { new Guid("19e4f770-9a6f-4657-9848-b21fbc085f06"), "Cardiologia" });

            migrationBuilder.InsertData(
                table: "Especialidade",
                columns: new[] { "Id", "Nome" },
                values: new object[] { new Guid("71a7fb49-6784-4a13-b86c-53bf9993fec6"), "Oftalmologia" });

            migrationBuilder.InsertData(
                table: "Especialidade",
                columns: new[] { "Id", "Nome" },
                values: new object[] { new Guid("586ac784-3f70-4755-90a0-0529e5a5e998"), "Ortopedia e Traumatologia" });

            migrationBuilder.InsertData(
                table: "Especialidade",
                columns: new[] { "Id", "Nome" },
                values: new object[] { new Guid("78fd1b38-f973-43b8-bc1d-468fcc9eee9c"), "Anestesiologia" });

            migrationBuilder.InsertData(
                table: "Especialidade",
                columns: new[] { "Id", "Nome" },
                values: new object[] { new Guid("672c272e-390a-4553-bd2b-e38c6d53d7f9"), "Ginecologia e Obstetrícia" });

            migrationBuilder.InsertData(
                table: "Especialidade",
                columns: new[] { "Id", "Nome" },
                values: new object[] { new Guid("4b930a2a-13b1-453e-b359-3a237d1eec6b"), "Pediatria" });

            migrationBuilder.InsertData(
                table: "Especialidade",
                columns: new[] { "Id", "Nome" },
                values: new object[] { new Guid("390d5ecd-ed80-498b-b8ae-866fb0c2556c"), "Cirurgia Geral" });

            migrationBuilder.InsertData(
                table: "Especialidade",
                columns: new[] { "Id", "Nome" },
                values: new object[] { new Guid("223bc23c-c660-4b74-bce3-dd1c80f84c46"), "Clínica Médica" });

            migrationBuilder.InsertData(
                table: "Especialidade",
                columns: new[] { "Id", "Nome" },
                values: new object[] { new Guid("ca3db56c-d492-45ac-ab98-497c19812fd0"), "Psiquiatria" });

            migrationBuilder.InsertData(
                table: "Especialidade",
                columns: new[] { "Id", "Nome" },
                values: new object[] { new Guid("49b1cdd6-9bb1-40b9-a255-201738c8830d"), "Nutrologia" });

            migrationBuilder.CreateIndex(
                name: "IX_Administrador_FuncionarioId",
                table: "Administrador",
                column: "FuncionarioId");

            migrationBuilder.CreateIndex(
                name: "IX_Funcionario_CargoId",
                table: "Funcionario",
                column: "CargoId");

            migrationBuilder.CreateIndex(
                name: "IX_HorarioDeTrabalho_MedicoId",
                table: "HorarioDeTrabalho",
                column: "MedicoId");

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

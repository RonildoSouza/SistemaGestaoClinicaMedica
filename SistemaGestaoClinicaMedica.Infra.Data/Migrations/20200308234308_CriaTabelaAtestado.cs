using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SistemaGestaoClinicaMedica.Infra.Data.Migrations
{
    public partial class CriaTabelaAtestado : Migration
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
                name: "Fabricante",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Nome = table.Column<string>(maxLength: 500, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Fabricante", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Paciente",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Nome = table.Column<string>(maxLength: 500, nullable: false),
                    DataNascimento = table.Column<DateTime>(nullable: false),
                    Telefone = table.Column<string>(maxLength: 20, nullable: false),
                    Bairro = table.Column<string>(maxLength: 500, nullable: false),
                    Cidade = table.Column<string>(maxLength: 500, nullable: false),
                    Estado = table.Column<string>(maxLength: 50, nullable: false),
                    Ativo = table.Column<bool>(nullable: false, defaultValue: true),
                    CriadoEm = table.Column<DateTime>(nullable: false, defaultValueSql: "date('now')"),
                    CriadoPor = table.Column<string>(nullable: true),
                    AtualizadoEm = table.Column<DateTime>(nullable: true),
                    AtualizadoPor = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Paciente", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Receita",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Observacao = table.Column<string>(nullable: true),
                    CriadoEm = table.Column<DateTime>(nullable: false),
                    CriadoPor = table.Column<string>(nullable: true),
                    AtualizadoEm = table.Column<DateTime>(nullable: true),
                    AtualizadoPor = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Receita", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "StatusConsulta",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Nome = table.Column<string>(maxLength: 500, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StatusConsulta", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "StatusExame",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Nome = table.Column<string>(maxLength: 500, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StatusExame", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TipoDeAtestado",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Nome = table.Column<string>(maxLength: 500, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TipoDeAtestado", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TipoDeExame",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Nome = table.Column<string>(maxLength: 500, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TipoDeExame", x => x.Id);
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
                    CargoId = table.Column<string>(nullable: false),
                    Ativo = table.Column<bool>(nullable: false, defaultValue: true),
                    CriadoEm = table.Column<DateTime>(nullable: false, defaultValueSql: "date('now')"),
                    CriadoPor = table.Column<string>(nullable: true),
                    AtualizadoEm = table.Column<DateTime>(nullable: true),
                    AtualizadoPor = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Funcionario", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Funcionario_Cargo_CargoId",
                        column: x => x.CargoId,
                        principalTable: "Cargo",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Medicamento",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Nome = table.Column<string>(maxLength: 100, nullable: false),
                    NomeFabrica = table.Column<string>(maxLength: 100, nullable: false),
                    Tarja = table.Column<string>(maxLength: 50, nullable: false),
                    Ativo = table.Column<bool>(nullable: false, defaultValue: true),
                    FabricanteId = table.Column<Guid>(nullable: false),
                    ReceitaId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Medicamento", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Medicamento_Fabricante_FabricanteId",
                        column: x => x.FabricanteId,
                        principalTable: "Fabricante",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Medicamento_Receita_ReceitaId",
                        column: x => x.ReceitaId,
                        principalTable: "Receita",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Administrador",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    FuncionarioId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Administrador", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Administrador_Funcionario_FuncionarioId",
                        column: x => x.FuncionarioId,
                        principalTable: "Funcionario",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Laboratorio",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    DaClinica = table.Column<bool>(nullable: false),
                    FuncionarioId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Laboratorio", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Laboratorio_Funcionario_FuncionarioId",
                        column: x => x.FuncionarioId,
                        principalTable: "Funcionario",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Medico",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CRM = table.Column<string>(maxLength: 50, nullable: false),
                    FuncionarioId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Medico", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Medico_Funcionario_FuncionarioId",
                        column: x => x.FuncionarioId,
                        principalTable: "Funcionario",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Recepcionista",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    FuncionarioId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Recepcionista", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Recepcionista_Funcionario_FuncionarioId",
                        column: x => x.FuncionarioId,
                        principalTable: "Funcionario",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Consulta",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Data = table.Column<DateTime>(nullable: false),
                    Observacao = table.Column<string>(maxLength: 500, nullable: true),
                    StatusConsultaId = table.Column<string>(nullable: false),
                    PacienteId = table.Column<Guid>(nullable: false),
                    MedicoId = table.Column<Guid>(nullable: false),
                    EspecialidadeId = table.Column<Guid>(nullable: false),
                    ReceitaId = table.Column<Guid>(nullable: true),
                    CriadoEm = table.Column<DateTime>(nullable: false),
                    CriadoPor = table.Column<string>(nullable: true),
                    AtualizadoPor = table.Column<string>(nullable: true),
                    AtualizadoEm = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Consulta", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Consulta_Especialidade_EspecialidadeId",
                        column: x => x.EspecialidadeId,
                        principalTable: "Especialidade",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Consulta_Medico_MedicoId",
                        column: x => x.MedicoId,
                        principalTable: "Medico",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Consulta_Paciente_PacienteId",
                        column: x => x.PacienteId,
                        principalTable: "Paciente",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Consulta_Receita_ReceitaId",
                        column: x => x.ReceitaId,
                        principalTable: "Receita",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Consulta_StatusConsulta_StatusConsultaId",
                        column: x => x.StatusConsultaId,
                        principalTable: "StatusConsulta",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
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

            migrationBuilder.CreateTable(
                name: "Atestado",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Observacao = table.Column<string>(maxLength: 500, nullable: true),
                    TipoDeAtestadoId = table.Column<string>(nullable: false),
                    ConsultaId = table.Column<Guid>(nullable: false),
                    CriadoEm = table.Column<DateTime>(nullable: false),
                    CriadoPor = table.Column<string>(nullable: true),
                    AtualizadoEm = table.Column<DateTime>(nullable: true),
                    AtualizadoPor = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Atestado", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Atestado_Consulta_ConsultaId",
                        column: x => x.ConsultaId,
                        principalTable: "Consulta",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Atestado_TipoDeAtestado_TipoDeAtestadoId",
                        column: x => x.TipoDeAtestadoId,
                        principalTable: "TipoDeAtestado",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Exame",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    TipoDeExameId = table.Column<Guid>(nullable: false),
                    Observacao = table.Column<string>(maxLength: 500, nullable: true),
                    StatusExameId = table.Column<string>(nullable: false),
                    LaboratorioRealizouExameId = table.Column<Guid>(nullable: true),
                    ConsultaId = table.Column<Guid>(nullable: false),
                    LinkResultadoExame = table.Column<string>(maxLength: 500, nullable: true),
                    CriadoEm = table.Column<DateTime>(nullable: false),
                    CriadoPor = table.Column<string>(nullable: true),
                    AtualizadoEm = table.Column<DateTime>(nullable: true),
                    AtualizadoPor = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Exame", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Exame_Consulta_ConsultaId",
                        column: x => x.ConsultaId,
                        principalTable: "Consulta",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Exame_Laboratorio_LaboratorioRealizouExameId",
                        column: x => x.LaboratorioRealizouExameId,
                        principalTable: "Laboratorio",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Exame_StatusExame_StatusExameId",
                        column: x => x.StatusExameId,
                        principalTable: "StatusExame",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Exame_TipoDeExame_TipoDeExameId",
                        column: x => x.TipoDeExameId,
                        principalTable: "TipoDeExame",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Administrador_FuncionarioId",
                table: "Administrador",
                column: "FuncionarioId");

            migrationBuilder.CreateIndex(
                name: "IX_Atestado_ConsultaId",
                table: "Atestado",
                column: "ConsultaId");

            migrationBuilder.CreateIndex(
                name: "IX_Atestado_TipoDeAtestadoId",
                table: "Atestado",
                column: "TipoDeAtestadoId");

            migrationBuilder.CreateIndex(
                name: "IX_Cargo_Id_Nome",
                table: "Cargo",
                columns: new[] { "Id", "Nome" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Consulta_EspecialidadeId",
                table: "Consulta",
                column: "EspecialidadeId");

            migrationBuilder.CreateIndex(
                name: "IX_Consulta_MedicoId",
                table: "Consulta",
                column: "MedicoId");

            migrationBuilder.CreateIndex(
                name: "IX_Consulta_PacienteId",
                table: "Consulta",
                column: "PacienteId");

            migrationBuilder.CreateIndex(
                name: "IX_Consulta_ReceitaId",
                table: "Consulta",
                column: "ReceitaId");

            migrationBuilder.CreateIndex(
                name: "IX_Consulta_StatusConsultaId",
                table: "Consulta",
                column: "StatusConsultaId");

            migrationBuilder.CreateIndex(
                name: "IX_Especialidade_Id_Nome",
                table: "Especialidade",
                columns: new[] { "Id", "Nome" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Exame_ConsultaId",
                table: "Exame",
                column: "ConsultaId");

            migrationBuilder.CreateIndex(
                name: "IX_Exame_LaboratorioRealizouExameId",
                table: "Exame",
                column: "LaboratorioRealizouExameId");

            migrationBuilder.CreateIndex(
                name: "IX_Exame_StatusExameId",
                table: "Exame",
                column: "StatusExameId");

            migrationBuilder.CreateIndex(
                name: "IX_Exame_TipoDeExameId",
                table: "Exame",
                column: "TipoDeExameId");

            migrationBuilder.CreateIndex(
                name: "IX_Fabricante_Nome",
                table: "Fabricante",
                column: "Nome",
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
                name: "IX_Medicamento_FabricanteId",
                table: "Medicamento",
                column: "FabricanteId");

            migrationBuilder.CreateIndex(
                name: "IX_Medicamento_ReceitaId",
                table: "Medicamento",
                column: "ReceitaId");

            migrationBuilder.CreateIndex(
                name: "IX_Medicamento_Nome_NomeFabrica",
                table: "Medicamento",
                columns: new[] { "Nome", "NomeFabrica" },
                unique: true);

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

            migrationBuilder.CreateIndex(
                name: "IX_StatusConsulta_Id_Nome",
                table: "StatusConsulta",
                columns: new[] { "Id", "Nome" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_StatusExame_Id_Nome",
                table: "StatusExame",
                columns: new[] { "Id", "Nome" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_TipoDeAtestado_Id_Nome",
                table: "TipoDeAtestado",
                columns: new[] { "Id", "Nome" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_TipoDeExame_Id_Nome",
                table: "TipoDeExame",
                columns: new[] { "Id", "Nome" },
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Administrador");

            migrationBuilder.DropTable(
                name: "Atestado");

            migrationBuilder.DropTable(
                name: "Exame");

            migrationBuilder.DropTable(
                name: "HorarioDeTrabalho");

            migrationBuilder.DropTable(
                name: "Medicamento");

            migrationBuilder.DropTable(
                name: "MedicoEspecialidade");

            migrationBuilder.DropTable(
                name: "Recepcionista");

            migrationBuilder.DropTable(
                name: "TipoDeAtestado");

            migrationBuilder.DropTable(
                name: "Consulta");

            migrationBuilder.DropTable(
                name: "Laboratorio");

            migrationBuilder.DropTable(
                name: "StatusExame");

            migrationBuilder.DropTable(
                name: "TipoDeExame");

            migrationBuilder.DropTable(
                name: "Fabricante");

            migrationBuilder.DropTable(
                name: "Especialidade");

            migrationBuilder.DropTable(
                name: "Medico");

            migrationBuilder.DropTable(
                name: "Paciente");

            migrationBuilder.DropTable(
                name: "Receita");

            migrationBuilder.DropTable(
                name: "StatusConsulta");

            migrationBuilder.DropTable(
                name: "Funcionario");

            migrationBuilder.DropTable(
                name: "Cargo");
        }
    }
}

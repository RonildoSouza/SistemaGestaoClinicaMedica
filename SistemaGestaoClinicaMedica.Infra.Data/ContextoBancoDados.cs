using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using SistemaGestaoClinicaMedica.Dominio.Entidades;
using SistemaGestaoClinicaMedica.Infra.Data.Mapeamentos;
using SistemaGestaoClinicaMedica.Infra.Data.Queries;
using System;

namespace SistemaGestaoClinicaMedica.Infra.Data
{
    public class ContextoBancoDados : DbContext
    {
        public ContextoBancoDados() { }

        public ContextoBancoDados(
            IFuncionariosQuery funcionariosQuery,
            IEspecialidadesQuery especialidadesQuery,
            IMedicamentosQuery medicamentosQuery,
            IFabricantesQuery fabricantesQuery)
        {
            funcionariosQuery.SetaContextoBD(this);
            FuncionariosQuery = funcionariosQuery;

            especialidadesQuery.SetaContextoBD(this);
            EspecialidadesQuery = especialidadesQuery;

            medicamentosQuery.SetaContextoBD(this);
            MedicamentosQuery = medicamentosQuery;

            fabricantesQuery.SetaContextoBD(this);
            FabricantesQuery = fabricantesQuery;
        }

        #region DbSets
        public DbSet<Funcionario> Funcionarios { get; set; }
        public DbSet<Cargo> Cargos { get; set; }
        public DbSet<Medico> Medicos { get; set; }
        public DbSet<Especialidade> Especialidades { get; set; }
        public DbSet<HorarioDeTrabalho> HorariosDeTrabalho { get; set; }
        public DbSet<Administrador> Administradores { get; set; }
        public DbSet<Recepcionista> Recepcionistas { get; set; }
        public DbSet<Laboratorio> Laboratorios { get; set; }
        public DbSet<Medicamento> Medicamentos { get; set; }
        public DbSet<Fabricante> Fabricantes { get; set; }
        //public DbSet<Receita> Receitas { get; set; }
        #endregion

        #region Queries
        public IFuncionariosQuery FuncionariosQuery { get; set; }
        public IEspecialidadesQuery EspecialidadesQuery { get; set; }
        public IMedicamentosQuery MedicamentosQuery { get; set; }
        public IFabricantesQuery FabricantesQuery { get; set; }
        #endregion

        public override int SaveChanges()
        {
            var _transaction = Database.BeginTransaction();

            try
            {
                var id = base.SaveChanges();
                _transaction.Commit();

                return id;
            }
            catch (Exception ex)
            {
                _transaction.Rollback();
                throw new Exception("Falha ao tentar salvar as alterações no banco de dados!", ex);
            }
            finally
            {
                _transaction.Dispose();
            }
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite(@"Data Source=BancoDados.db");
            optionsBuilder.EnableSensitiveDataLogging();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(MapeamentoBase<,>).Assembly);

            RemovePluralizingTableNameConvention(ref modelBuilder);

            base.OnModelCreating(modelBuilder);
        }

        private void RemovePluralizingTableNameConvention(ref ModelBuilder modelBuilder)
        {
            foreach (IMutableEntityType entity in modelBuilder.Model.GetEntityTypes())
                entity.SetTableName(entity.DisplayName());
        }
    }
}

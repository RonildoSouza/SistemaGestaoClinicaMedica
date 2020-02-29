using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using SistemaGestaoClinicaMedica.Dominio.Entidades;
using SistemaGestaoClinicaMedica.Infra.Data.Mapeamentos;
using SistemaGestaoClinicaMedica.Infra.Data.Queries;
using System;
using System.IO;

namespace SistemaGestaoClinicaMedica.Infra.Data
{
    public class ContextoBancoDados : DbContext
    {
        public ContextoBancoDados() { }

        public ContextoBancoDados(IFuncionarioQueries funcionarioQueries)
        {
            FuncionarioQueries = funcionarioQueries;
            funcionarioQueries.SetaContextoBD(this);
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
        //public DbSet<Receita> Receitas { get; set; }
        #endregion

        #region Queries
        public IFuncionarioQueries FuncionarioQueries { get; set; }
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

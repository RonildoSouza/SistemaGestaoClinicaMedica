using Microsoft.EntityFrameworkCore;
using SistemaGestaoClinicaMedica.Dominio.Entidades;
using SistemaGestaoClinicaMedica.Infra.Data.Queries;
using System;

namespace SistemaGestaoClinicaMedica.Infra.Data
{
    public class ContextoBancoDados : DbContext
    {
        public ContextoBancoDados(
            DbContextOptions<ContextoBancoDados> options,
            IFuncionarioQueries funcionarioQueries) : base(options)
        {
            funcionarioQueries.SetaContextoBD(this);
        }

        #region DbSets
        public DbSet<Funcionario> Funcionarios { get; set; }
        public DbSet<Receita> Receitas { get; set; }
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
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}

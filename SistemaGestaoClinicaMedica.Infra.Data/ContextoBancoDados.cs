using Microsoft.EntityFrameworkCore;
using SistemaGestaoClinicaMedica.Dominio.Entidades;
using SistemaGestaoClinicaMedica.Infra.Data.Queries;
using System;
using System.Collections.Generic;

namespace SistemaGestaoClinicaMedica.Infra.Data
{
    public class ContextoBancoDados : DbContext
    {
        public ContextoBancoDados(
            DbContextOptions<ContextoBancoDados> options,
            IFuncionarioQueries funcionarioQueries) : base(options)
        {
            FuncionarioQueries = funcionarioQueries;
            funcionarioQueries.SetaContextoBD(this);
        }

        #region FAKE DBSET
        public IEnumerable<Funcionario> Funcionarios => DadosFake.Funcionarios();
        public IEnumerable<Cargo> Cargos => DadosFake.Cargos();
        #endregion

        #region DbSets
        //public DbSet<Funcionario> Funcionarios { get; set; }
        //public DbSet<Cargo> Cargos { get; set; }
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
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}

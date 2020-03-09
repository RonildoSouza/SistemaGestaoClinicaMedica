using Microsoft.AspNetCore.Http;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using SistemaGestaoClinicaMedica.Dominio.Entidades;
using SistemaGestaoClinicaMedica.Infra.Data.Mapeamentos;
using System;

namespace SistemaGestaoClinicaMedica.Infra.Data
{
    public class ContextoBancoDados : DbContext
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        public ContextoBancoDados() { }

        public ContextoBancoDados(IHttpContextAccessor httpContextAccessor) : this()
        {
            _httpContextAccessor = httpContextAccessor;
        }

        /// <summary>Unit Of Work</summary>
        public override int SaveChanges()
        {
            var _transaction = Database.BeginTransaction();

            try
            {
                AuditaEntidades();
                var id = base.SaveChanges();
                _transaction.Commit();

                return id;
            }
            catch (SqliteException ex)
            {
                _transaction.Rollback();
                throw new Exception($"Falha ao tentar salvar as alterações no banco de dados! \n\t{ex.Message}");
            }
            finally
            {
                _transaction.Dispose();
            }
        }

        private void AuditaEntidades()
        {
            var entries = ChangeTracker.Entries();
            foreach (var entry in entries)
            {
                if (!(entry.Entity is IEntidadeAuditada entidadeAuditada))
                    continue;

                var dataAtual = DateTime.Now;
                var nomeUsuarioLogado = ObterNomeUsuarioLogado();

                switch (entry.State)
                {
                    case EntityState.Modified:
                        entidadeAuditada.AtualizadoEm = dataAtual;
                        entidadeAuditada.AtualizadoPor = nomeUsuarioLogado;

                        Entry(entidadeAuditada).Property(_ => _.CriadoEm).IsModified = false;
                        Entry(entidadeAuditada).Property(_ => _.CriadoPor).IsModified = false;
                        break;

                    case EntityState.Added:
                        entidadeAuditada.CriadoEm = dataAtual;
                        entidadeAuditada.CriadoPor = nomeUsuarioLogado;
                        break;
                }
            }
        }

        private string ObterNomeUsuarioLogado()
        {
            var nomeUsuarioLogado = _httpContextAccessor.HttpContext.User.Identity.Name;
            return nomeUsuarioLogado;
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

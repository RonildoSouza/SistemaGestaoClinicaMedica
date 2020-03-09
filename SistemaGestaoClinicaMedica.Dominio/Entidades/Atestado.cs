using System;

namespace SistemaGestaoClinicaMedica.Dominio.Entidades
{
    public class Atestado : IEntidade<Guid>, IEntidadeAuditada
    {
        public Atestado() { }

        public Atestado(Guid id, string observacao, TipoDeAtestado tipoDeAtestado, Consulta consulta)
        {
            Id = id;
            Observacao = observacao;
            TipoDeAtestado = tipoDeAtestado;
            Consulta = consulta;
        }

        public Guid Id { get; set; }
        public string Observacao { get; set; }
        public TipoDeAtestado TipoDeAtestado { get; set; }
        public Consulta Consulta { get; set; }
        public DateTime CriadoEm { get; set; }
        public string CriadoPor { get; set; }
        public DateTime? AtualizadoEm { get; set; }
        public string AtualizadoPor { get; set; }
    }
}
using System;

namespace SistemaGestaoClinicaMedica.Dominio.Entidades
{
    public class Exame : IEntidade<Guid>
    {
        public Exame() { }

        public Exame(Guid id, TipoDeExame tipoDeExame, string observacao, StatusExame statusExame, Laboratorio laboratorioRealizouExame, Consulta consulta, string linkResultadoExame)
        {
            Id = id;
            TipoDeExame = tipoDeExame;
            Observacao = observacao;
            StatusExame = statusExame;
            LaboratorioRealizouExame = laboratorioRealizouExame;
            Consulta = consulta;
            LinkResultadoExame = linkResultadoExame;
        }

        public Guid Id { get; set; }
        public TipoDeExame TipoDeExame { get; set; }
        public string Observacao { get; set; }
        public StatusExame StatusExame { get; set; }
        public Laboratorio LaboratorioRealizouExame { get; set; }
        public Consulta Consulta { get; set; }
        public string LinkResultadoExame { get; set; }
        public DateTime CriadoEm { get; set; }
    }
}
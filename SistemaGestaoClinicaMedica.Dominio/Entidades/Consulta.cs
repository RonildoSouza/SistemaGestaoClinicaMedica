using System;
using System.Collections.Generic;
using System.Text;

namespace SistemaGestaoClinicaMedica.Dominio.Entidades
{
    public class Consulta
    {
        public Guid Id { get; set; }
        public DateTime Data { get; set; }
        public DateTime? DataRetorno { get; set; }
        public string Observacao { get; set; }
        public StatusConsulta StatusConsulta { get; set; }
        public DateTime CriadoEm { get; set; }
        public DateTime AtualizadoEm { get; set; }
        public List<Exame> Exames { get; set; }
    }
}

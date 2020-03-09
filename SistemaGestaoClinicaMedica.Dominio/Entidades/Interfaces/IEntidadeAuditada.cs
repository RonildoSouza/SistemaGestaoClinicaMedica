using System;

namespace SistemaGestaoClinicaMedica.Dominio.Entidades
{
    public interface IEntidadeAuditada
    {
        DateTime CriadoEm { get; set; }
        string CriadoPor { get; set; }
        DateTime? AtualizadoEm { get; set; }
        string AtualizadoPor { get; set; }
    }
}

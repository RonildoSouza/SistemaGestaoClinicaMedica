using System;

namespace SistemaGestaoClinicaMedica.Aplicacao.DTOS.Funcionario.Medico
{
    public class MedicoEspecialidadeEntradaDTO : IEntradaDTO<Guid>
    {
        public Guid Id { get; set; }
        public string EspecialidadeId { get; set; }
    }
}

using AutoMapper;
using SistemaGestaoClinicaMedica.Aplicacao.DTOS.Consulta;
using SistemaGestaoClinicaMedica.Dominio.Entidades;
using SistemaGestaoClinicaMedica.Dominio.Servicos;
using System;

namespace SistemaGestaoClinicaMedica.Aplicacao.AutoMapper.TypeConverters
{
    public class ConsultaEntradaDTOParaConsulta : ITypeConverter<ConsultaEntradaDTO, Consulta>
    {
        private readonly IStatusConsultaServico _statusConsultaServico;
        private readonly IPacienteServico _pacienteServico;
        private readonly IMedicoServico _medicoServico;
        private readonly IEspecialidadeServico _especialidadeServico;

        public ConsultaEntradaDTOParaConsulta(IStatusConsultaServico statusConsultaServico, IPacienteServico pacienteServico, IMedicoServico medicoServico, IEspecialidadeServico especialidadeServico)
        {
            _statusConsultaServico = statusConsultaServico;
            _pacienteServico = pacienteServico;
            _medicoServico = medicoServico;
            _especialidadeServico = especialidadeServico;
        }

        public Consulta Convert(ConsultaEntradaDTO source, Consulta destination, ResolutionContext context)
        {
            StatusConsulta statusConsulta = null;
            Paciente paciente = null;
            Medico medico = null;
            Especialidade especialidade = null;

            if (Enum.TryParse(source.StatusConsultaId, out EStatusConsulta eStatusConsulta))
                statusConsulta = _statusConsultaServico.Obter(eStatusConsulta);

            if (Guid.TryParse(source.PacienteId, out Guid pacienteId))
                paciente = _pacienteServico.Obter(pacienteId);

            if (Guid.TryParse(source.MedicoId, out Guid medicoId))
                medico = _medicoServico.Obter(medicoId);

            if (Guid.TryParse(source.EspecialidadeId, out Guid especialidadeId))
                especialidade = _especialidadeServico.Obter(especialidadeId);

            return new Consulta(
                source.Id,
                source.Data,
                source.Observacao,
                statusConsulta,
                paciente,
                medico,
                especialidade);
        }
    }
}

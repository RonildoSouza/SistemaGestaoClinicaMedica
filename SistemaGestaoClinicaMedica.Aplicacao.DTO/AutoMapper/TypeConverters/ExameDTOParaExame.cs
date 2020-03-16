using AutoMapper;
using SistemaGestaoClinicaMedica.Dominio.Entidades;
using SistemaGestaoClinicaMedica.Dominio.Servicos;
using System;

namespace SistemaGestaoClinicaMedica.Aplicacao.DTO.AutoMapper.TypeConverters
{
    public class ExameDTOParaExame : ITypeConverter<ExameDTO, Exame>
    {
        private readonly ITipoDeExameServico _tipoDeExameServico;
        private readonly IStatusExameServico _statusExameServico;
        private readonly ILaboratorioServico _laboratorioServico;
        private readonly IConsultaServico _consultaServico;

        public ExameDTOParaExame(ITipoDeExameServico tipoDeExameServico, IStatusExameServico statusExameServico, ILaboratorioServico laboratorioServico, IConsultaServico consultaServico)
        {
            _tipoDeExameServico = tipoDeExameServico;
            _statusExameServico = statusExameServico;
            _laboratorioServico = laboratorioServico;
            _consultaServico = consultaServico;
        }

        public Exame Convert(ExameDTO source, Exame destination, ResolutionContext context)
        {
            TipoDeExame tipoDeExame = _tipoDeExameServico.Obter(source.TipoDeExameId);
            StatusExame statusExame = null;
            Laboratorio laboratorio = _laboratorioServico.Obter(source.LaboratorioRealizouExameId.GetValueOrDefault());
            Consulta consulta = _consultaServico.Obter(source.ConsultaId);

            if (Enum.TryParse(source.StatusExameId, out EStatusExame eStatusExame))
                statusExame = _statusExameServico.Obter(eStatusExame);

            return new Exame(
                source.Id,
                tipoDeExame,
                source.Observacao,
                statusExame,
                laboratorio,
                consulta,
                source.LinkResultadoExame);
        }
    }
}

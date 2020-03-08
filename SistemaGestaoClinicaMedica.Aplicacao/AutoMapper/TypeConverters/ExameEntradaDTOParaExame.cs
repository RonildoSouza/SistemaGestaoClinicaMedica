using AutoMapper;
using SistemaGestaoClinicaMedica.Aplicacao.DTOS.Exame;
using SistemaGestaoClinicaMedica.Dominio.Entidades;
using SistemaGestaoClinicaMedica.Dominio.Servicos;
using System;

namespace SistemaGestaoClinicaMedica.Aplicacao.AutoMapper.TypeConverters
{
    public class ExameEntradaDTOParaExame : ITypeConverter<ExameEntradaDTO, Exame>
    {
        private readonly ITipoDeExameServico _tipoDeExameServico;
        private readonly IStatusExameServico _statusExameServico;
        private readonly ILaboratorioServico _laboratorioServico;
        private readonly IConsultaServico _consultaServico;

        public ExameEntradaDTOParaExame(ITipoDeExameServico tipoDeExameServico, IStatusExameServico statusExameServico, ILaboratorioServico laboratorioServico, IConsultaServico consultaServico)
        {
            _tipoDeExameServico = tipoDeExameServico;
            _statusExameServico = statusExameServico;
            _laboratorioServico = laboratorioServico;
            _consultaServico = consultaServico;
        }

        public Exame Convert(ExameEntradaDTO source, Exame destination, ResolutionContext context)
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

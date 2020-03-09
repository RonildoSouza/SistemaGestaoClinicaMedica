using AutoMapper;
using SistemaGestaoClinicaMedica.Aplicacao.DTOS.Atestado;
using SistemaGestaoClinicaMedica.Dominio.Entidades;
using SistemaGestaoClinicaMedica.Dominio.Servicos;
using System;

namespace SistemaGestaoClinicaMedica.Aplicacao.AutoMapper.TypeConverters
{
    public class AtestadoEntradaDTOParaAtestado : ITypeConverter<AtestadoEntradaDTO, Atestado>
    {
        private readonly ITipoDeAtestadoServico _tipoDeAtestadoServico;
        private readonly IConsultaServico _consultaServico;

        public AtestadoEntradaDTOParaAtestado(ITipoDeAtestadoServico tipoDeAtestadoServico, IConsultaServico consultaServico)
        {
            _tipoDeAtestadoServico = tipoDeAtestadoServico;
            _consultaServico = consultaServico;
        }

        public Atestado Convert(AtestadoEntradaDTO source, Atestado destination, ResolutionContext context)
        {
            TipoDeAtestado tipoDeAtestado = null;
            Consulta consulta = _consultaServico.Obter(source.ConsultaId);

            if (Enum.TryParse(source.TipoDeAtestadoId, out ETipoDeAtestado eTipoDeAtestadoId))
                tipoDeAtestado = _tipoDeAtestadoServico.Obter(eTipoDeAtestadoId);

            return new Atestado(
                source.Id,
                source.Observacao,
                tipoDeAtestado,
                consulta);
        }
    }
}

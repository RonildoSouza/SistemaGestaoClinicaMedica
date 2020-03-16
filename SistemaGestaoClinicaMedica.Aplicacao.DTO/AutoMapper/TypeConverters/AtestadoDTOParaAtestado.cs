using AutoMapper;
using SistemaGestaoClinicaMedica.Dominio.Entidades;
using SistemaGestaoClinicaMedica.Dominio.Servicos;
using System;

namespace SistemaGestaoClinicaMedica.Aplicacao.DTO.AutoMapper.TypeConverters
{
    public class AtestadoDTOParaAtestado : ITypeConverter<AtestadoDTO, Atestado>
    {
        private readonly ITipoDeAtestadoServico _tipoDeAtestadoServico;
        private readonly IConsultaServico _consultaServico;

        public AtestadoDTOParaAtestado(ITipoDeAtestadoServico tipoDeAtestadoServico, IConsultaServico consultaServico)
        {
            _tipoDeAtestadoServico = tipoDeAtestadoServico;
            _consultaServico = consultaServico;
        }

        public Atestado Convert(AtestadoDTO source, Atestado destination, ResolutionContext context)
        {
            TipoDeAtestado tipoDeAtestado = null;
            Consulta consulta = _consultaServico.Obter(source.ConsultaId);

            if (Enum.TryParse(source.TipoDeAtestado.Id, out ETipoDeAtestado eTipoDeAtestadoId))
                tipoDeAtestado = _tipoDeAtestadoServico.Obter(eTipoDeAtestadoId);

            return new Atestado(
                source.Id,
                source.Observacao,
                tipoDeAtestado,
                consulta);
        }
    }
}

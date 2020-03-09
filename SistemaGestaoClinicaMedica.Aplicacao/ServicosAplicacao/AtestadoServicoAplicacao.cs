using AutoMapper;
using SistemaGestaoClinicaMedica.Aplicacao.DTOS.Atestado;
using SistemaGestaoClinicaMedica.Dominio.Entidades;
using SistemaGestaoClinicaMedica.Dominio.Servicos;
using System;

namespace SistemaGestaoClinicaMedica.Aplicacao.ServicosAplicacao
{
    public class AtestadoServicoAplicacao : ServicoAplicacaoBase<Atestado, AtestadoSaidaDTO, AtestadoEntradaDTO, Guid>, IAtestadoServicoAplicacao
    {
        public AtestadoServicoAplicacao(IMapper mapper, IAtestadoServico atestadoServico) : base(mapper, atestadoServico)
        {
        }
    }
}

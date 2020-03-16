using AutoMapper;
using SistemaGestaoClinicaMedica.Aplicacao.DTO;
using SistemaGestaoClinicaMedica.Dominio.Entidades;
using SistemaGestaoClinicaMedica.Dominio.Servicos;
using System;

namespace SistemaGestaoClinicaMedica.Aplicacao.ServicosAplicacao
{
    public sealed class AtestadoServicoAplicacao : ServicoAplicacaoBase<AtestadoDTO, Guid, Atestado>, IAtestadoServicoAplicacao
    {
        public AtestadoServicoAplicacao(IMapper mapper, IAtestadoServico atestadoServico) : base(mapper, atestadoServico)
        {
        }
    }
}

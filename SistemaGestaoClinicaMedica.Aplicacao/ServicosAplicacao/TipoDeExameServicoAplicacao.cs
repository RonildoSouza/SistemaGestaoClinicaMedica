using AutoMapper;
using SistemaGestaoClinicaMedica.Aplicacao.DTO;
using SistemaGestaoClinicaMedica.Dominio.Entidades;
using SistemaGestaoClinicaMedica.Dominio.Servicos;
using System;

namespace SistemaGestaoClinicaMedica.Aplicacao.ServicosAplicacao
{
    public sealed class TipoDeExameServicoAplicacao : ServicoAplicacaoLeitura<TipoDeExameDTO, Guid, TipoDeExame>, ITipoDeExameServicoAplicacao
    {
        public TipoDeExameServicoAplicacao(IMapper mapper, ITipoDeExameServico tipoDeExameServico) : base(mapper, tipoDeExameServico)
        {
        }
    }
}

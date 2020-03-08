using AutoMapper;
using SistemaGestaoClinicaMedica.Aplicacao.DTOS.Exame;
using SistemaGestaoClinicaMedica.Dominio.Entidades;
using SistemaGestaoClinicaMedica.Dominio.Servicos;
using System;

namespace SistemaGestaoClinicaMedica.Aplicacao.ServicosAplicacao
{
    public sealed class TipoDeExameServicoAplicacao : ServicoAplicacaoLeitura<TipoDeExame, TipoDeExameSaidaDTO, Guid>, ITipoDeExameServicoAplicacao
    {
        public TipoDeExameServicoAplicacao(IMapper mapper, ITipoDeExameServico tipoDeExameServico) : base(mapper, tipoDeExameServico)
        {
        }
    }
}
